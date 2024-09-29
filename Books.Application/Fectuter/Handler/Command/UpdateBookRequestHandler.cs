using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Fectuter.Handler.Command
{
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, string>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public UpdateBookRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
            this.uniteofwork = uniteofwork;
            this.mapper = mapper;

        }
        public async Task<string> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var FindBookIsbn =   uniteofwork.BookRepository.GetBookById(request.BookDTO.ISBN);
            var Bookmap = mapper.Map<BookDTO, Domain.NormalDomin.BookModel>(request.BookDTO,FindBookIsbn);
            uniteofwork.BookRepository.UpdateBook(Bookmap);
            uniteofwork.SaveChanges();
            var bookdto = mapper.Map<BookDTO>(Bookmap);
            return bookdto.ISBN;
        }
    }
}
