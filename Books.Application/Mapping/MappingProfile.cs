using AutoMapper;
using Books.Application.DTO.Book;
using Books.Domain.NormalDomin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<BookModel, BookDTO>().ReverseMap();
        
        }
    }
}
