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
    public class DeleteBooksRequestHandler : IRequestHandler<DeleteBooksRequest, int>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public DeleteBooksRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
          this.uniteofwork= uniteofwork;
            this.mapper= mapper;
        }
        public async Task<int> Handle(DeleteBooksRequest request, CancellationToken cancellationToken)
        {

            var FindBookIsbn = uniteofwork.BookRepository.GetBookById(request.BookDTO.Id);
            var Bookmap = mapper.Map<BookDTO>(FindBookIsbn);
            uniteofwork.BookRepository.DeleteBook(FindBookIsbn) ;
            uniteofwork.SaveChanges();
            var bookdto = mapper.Map<BookDTO>(Bookmap);
            return bookdto.Id;

        }
    }
}
