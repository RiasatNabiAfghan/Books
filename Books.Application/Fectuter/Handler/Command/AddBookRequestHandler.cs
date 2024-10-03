using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using MediatR;

namespace Books.Application.Fectuter.Handler.Command
{
    public class AddBookRequestHandler : IRequestHandler<AddBookRequest, BookDTO>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public AddBookRequestHandler(Iuniteofwork uniteofwork, IMapper mapper)
        {
            this.uniteofwork = uniteofwork;
            this.mapper = mapper;
        }
        public async Task<BookDTO> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();    
        }

    }
}
