using Books.Domain.BaseDomin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.NormalDomin
{
    public class BookModel:BaseDomins
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public String ISBN {  get; set; }
        [Required]
        public string Author {  get; set; }
        [Required]
        public DateOnly PublishDate { get; set; }   
    }
     
}
