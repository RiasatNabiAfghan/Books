using Books.Application.Presistance;
using Books.Domain.NormalDomin;
using Books.Infrastructer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructer.Services
{
    public class BookServices : GenericRepository<BookModel>, IBooks
    {
        public BookServices(ApplicationDbcontext context) : base(context)
        {
        }
    }
}
