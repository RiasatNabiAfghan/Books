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
    public class GetBookByIdRequestHandler : IRequestHandler<GetBookByIdRequest, BookDTO>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public GetBookByIdRequestHandler(Iuniteofwork uniteofwork,IMapper mapper)
        {
            this.uniteofwork = uniteofwork;
            this.mapper= mapper;
        }
        public async Task<BookDTO> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            var FindBook = uniteofwork.BookRepository.GetBookById(request.Id);
            var mapping=mapper.Map<BookDTO>(FindBook);
            return mapping;
        }
    }
}
