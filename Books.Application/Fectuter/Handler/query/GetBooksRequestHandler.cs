using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.query;
using Books.Application.Presistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Fectuter.Handler.query
{
    public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest, List<BookDTO>>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public GetBooksRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
          this.uniteofwork= uniteofwork;
          this.mapper= mapper;
        }
        public async Task<List<BookDTO>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var listbooks=await uniteofwork.BookRepository.GetAllBooks();
            var bookdto=mapper.Map<List<BookDTO>>(listbooks);
            return bookdto;
        }
    }
}
