using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Fectuter.Request.query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
namespace Books.Controllers
{
    public class BookController : Controller
    {
        private IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
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
        [HttpPost]
        public async Task<IActionResult> AddBooks(BookDTO bookDTO)
        {
                var addingbooks = await mediator.Send(new AddBookRequest { Bookdto = bookDTO });
                return Json(new { data = addingbooks });
        }
        [HttpGet]
        public async Task<IActionResult> GetBook(string isbn)
        {
            var findisbn = await mediator.Send(new GetBookByIdRequest {isbn=isbn});
            return Json(new { data = findisbn });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            var updatebook = await mediator.Send(new UpdateBookRequest {BookDTO=bookDTO });
            return Json(new {data=updatebook});
        }

        [HttpPost]
        public IActionResult DeletBooks(BookDTO bookDTO)
        {
           var removebooks=mediator.Send(new DeleteBooksRequest { BookDTO=bookDTO});
            return Json(new {data=removebooks});
        }


    }
}
