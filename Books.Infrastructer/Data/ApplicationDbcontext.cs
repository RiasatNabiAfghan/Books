using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Domain.NormalDomin;
using Microsoft.EntityFrameworkCore;
namespace Books.Infrastructer.Data
{
    public class ApplicationDbcontext :DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
        :base(options)
        {
        
        }
        public DbSet<BookModel> BookModel { get; set; }
       
    }
}
