using AutoMapper;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using MediatR;
using System.Text.RegularExpressions;

namespace Books.Application.Fectuter.Handler.Command
{
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, int>
    {
        private Iuniteofwork uniteofwork;
        private IMapper mapper;

        public UpdateBookRequestHandler(Iuniteofwork uniteofwork, IMapper mapper)
        {
            this.uniteofwork = uniteofwork;
            this.mapper = mapper;

        }
        public async Task<int> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var existingBook =  uniteofwork.BookRepository.GetBookById(request.UpdateBookDto.Id);
            mapper.Map(request.UpdateBookDto, existingBook);
             uniteofwork.SaveChanges();
            return existingBook.Id; 
        }
    }
}
     


    


    
    
