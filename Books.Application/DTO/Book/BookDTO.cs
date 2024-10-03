using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Application.DTO.Book
{
    public class BookDTO : BaseDto
    {
        [Display(Name = "ISBN"),Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Book Name is required.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publish Date is required.")]
        public DateOnly PublishDate { get; set; }
    }
}