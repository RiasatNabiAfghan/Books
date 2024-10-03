using Books.Application.DTO.Book;
using MediatR;

namespace Books.Application.Fectuter.Request.query
{
    public class GetBookByIdRequest:IRequest<BookDTO>
    {
        public int Id { get; set; } 
    }
}
