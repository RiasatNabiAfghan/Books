using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Fectuter.Request.query;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
namespace Books.Controllers
{
    public class BookController : Controller
    {
        private readonly IMediator mediator;
        private readonly IWebHostEnvironment hc;

        public BookController(IMediator mediator, IWebHostEnvironment hc)
        {
           this.mediator = mediator;
            this.hc = hc;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var listbooks = await mediator.Send(new GetBooksRequest());
            return Json(new { data = listbooks });
        }

        [HttpGet]
        public async Task<IActionResult> GetBook(int Id)
        {
            var findId = await mediator.Send(new GetBookByIdRequest { Id = Id });
            return Json(new { data = findId });
        }




        [HttpPost]
        public async Task<IActionResult> AddBooks(BookDTO bookDTO)
        {
            if (bookDTO.Photo != null)
            {
                bookDTO.PhotoPath = await UploadImageAsync(bookDTO.Photo);
            }

            var addingBooks = await mediator.Send(new AddBookRequest { Bookdto = bookDTO });
            return Json(new { data = addingBooks });
        }


        private async Task<string> UploadImageAsync(IFormFile photo)
        {
            string filename = Guid.NewGuid().ToString() + "-" + photo.FileName;
            string uploadFolder = Path.Combine(hc.WebRootPath, "images");
            string filePath = Path.Combine(uploadFolder, filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);  
            }

            return "/images/" + filename; 
        }



        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO updateBookDto)
        {
            if (updateBookDto.Photo != null)
            {
                // Remove the existing image if it exists
                if (!string.IsNullOrEmpty(updateBookDto.PhotoPath))
                {
                    RemoveExistingImage(updateBookDto.PhotoPath);
                }

                updateBookDto.PhotoPath = await UploadImageAsync(updateBookDto.Photo);
            }

            var updatedBookId = await mediator.Send(new UpdateBookRequest { UpdateBookDto = updateBookDto });
            return Json(new { data = updatedBookId });
        }

        private void RemoveExistingImage(string photoPath)
        {
            string fullPath = Path.Combine(hc.WebRootPath, photoPath.TrimStart('/'));

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath); // Remove the existing image
            }
        }






        [HttpPost]
        public IActionResult DeletBooks(BookDTO bookDTO)
        {
           var removebooks=mediator.Send(new DeleteBooksRequest { BookDTO=bookDTO});
            return Json(new {data=removebooks});
        }







    }
}
