using AutoMapper;
using Books.Application.DTO.Book;
using Books.Application.Fectuter.Request.Command;
using Books.Application.Presistance;
using Books.Domain.NormalDomin;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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
            var bookModel = mapper.Map<BookModel>(request.Bookdto);
            if (!string.IsNullOrEmpty(request.Bookdto.PhotoPath))
            {
                bookModel.PhotoPath = request.Bookdto.PhotoPath;
            }
            //for pdf
            if (!string.IsNullOrEmpty(request.Bookdto.PdfPath))
            {
                bookModel.PdfPath = request.Bookdto.PdfPath; // Set the PDF path for database
            }

            uniteofwork.BookRepository.AddBook(bookModel);
             uniteofwork.SaveChanges();
            var bookDto = mapper.Map<BookDTO>(bookModel);
            return bookDto;
        }

    }
}
