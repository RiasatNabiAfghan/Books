using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTO.Book
{
    public class UpdateBookDto:BookDTO
    {
        public int Id { get; set; }
        public string ExistingPhotoPath {  get; set; } 
    }
}
