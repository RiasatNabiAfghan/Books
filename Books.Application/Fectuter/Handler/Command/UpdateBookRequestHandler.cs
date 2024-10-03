using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using MediatR;

namespace Books.Application.Fectuter.Handler.Command
{
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, int>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public UpdateBookRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
            this.uniteofwork = uniteofwork;
            this.mapper = mapper;

        }
        public async Task<int> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var FindBookIsbn =   uniteofwork.BookRepository.GetBookById(request.BookDTO.Id);
            var Bookmap = mapper.Map<BookDTO, Domain.NormalDomin.BookModel>(request.BookDTO,FindBookIsbn);
            uniteofwork.BookRepository.UpdateBook(Bookmap);
            uniteofwork.SaveChanges();
            var bookdto = mapper.Map<BookDTO>(Bookmap);
            return bookdto.Id;
        }
    }
}
