using Books.Application.DTO.Book;
using MediatR;

namespace Books.Application.Fectuter.Request.Command
{
    public class UpdateBookRequest:IRequest<int>
    {
        public BookDTO UpdateBookDto { get; set; }
    }
}
