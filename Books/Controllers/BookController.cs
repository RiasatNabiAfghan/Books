using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Fectuter.Request.query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

            if (bookDTO.PdfFile != null)
            {
                bookDTO.PdfPath = await UploadPdfAsync(bookDTO.PdfFile); // Handle PDF upload
            }

            var addingBooks = await mediator.Send(new AddBookRequest { Bookdto = bookDTO });
            return Json(new { data = addingBooks });
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
           
            // Check if a new PDF is being uploaded
            if (updateBookDto.PdfFile != null)
            {
                // Remove the existing PDF if it exists
                if (!string.IsNullOrEmpty(updateBookDto.PdfPath))
                {
                    RemoveExistingPdf(updateBookDto.PdfPath);
                }

                // Upload the new PDF
                updateBookDto.PdfPath = await UploadPdfAsync(updateBookDto.PdfFile);
            }

            var updatedBookId = await mediator.Send(new UpdateBookRequest { UpdateBookDto = updateBookDto });
            return Json(new { data = updatedBookId });
        }
         




        [HttpPost]
        public IActionResult DeletBooks(BookDTO bookDTO)
        {
           var removebooks=mediator.Send(new DeleteBooksRequest { BookDTO=bookDTO});
            return Json(new {data=removebooks});
        }
        /// <summary>
        /// ////////////////// //private Methods////////////////
        /// </summary>
        /// <param name="photoPath"></param>

        private void RemoveExistingImage(string photoPath)
        {
            string fullPath = Path.Combine(hc.WebRootPath, photoPath.TrimStart('/'));

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath); // Remove the existing image
            }
        }


        private void RemoveExistingPdf(string pdfPath)
        {
            if (System.IO.File.Exists(pdfPath))
            {
                System.IO.File.Delete(pdfPath);
            }
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


        private async Task<string> UploadPdfAsync(IFormFile pdfFile)
        {
            string filename = Guid.NewGuid().ToString() + "-" + pdfFile.FileName;
            string uploadFolder = Path.Combine(hc.WebRootPath, "pdfs");
            string filePath = Path.Combine(uploadFolder, filename);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            return "/pdfs/" + filename; // Return the virtual path
        }

    }
}
