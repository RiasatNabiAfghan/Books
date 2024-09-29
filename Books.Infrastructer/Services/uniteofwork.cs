using Books.Application.Presistance;
using Books.Infrastructer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructer.Services
{
    public class Uniteofwork : Iuniteofwork
    {
        private ApplicationDbcontext context;
        public  IBooks _BookRepository;

        public Uniteofwork(ApplicationDbcontext context)
        {
            this.context = context;
        }
        public IBooks BookRepository
        {
            get
            {
                return _BookRepository=new BookServices(context);
            }
        }

        public void SaveChanges()
        {
           context.SaveChanges();
        }
    }
}
