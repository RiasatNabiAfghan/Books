using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Presistance
{

    public interface Iuniteofwork
    {
        public IBooks BookRepository { get; }
        void SaveChanges();
        
    }
}
