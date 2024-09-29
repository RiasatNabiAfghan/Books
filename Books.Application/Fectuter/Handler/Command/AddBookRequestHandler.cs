using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using Books.Domain.NormalDomin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Fectuter.Handler.Command
{
    public class AddBookRequestHandler : IRequestHandler<AddBookRequest, BookDTO>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public AddBookRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
           this.uniteofwork= uniteofwork;
            this.mapper= mapper;
        }
        public async Task<BookDTO> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
            var MappBook = mapper.Map<Domain.NormalDomin.BookModel>(request.Bookdto);
            uniteofwork.BookRepository.AddBook(MappBook);
            uniteofwork.SaveChanges();
            var bookdto = mapper.Map<BookDTO>(MappBook);
            return bookdto;
        }
    }
}
