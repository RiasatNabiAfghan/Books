using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Presistance
{
    public interface IGenericRepository<Entity> where Entity : class
    {
       Task<List<Entity>> GetAllBooks();
        Entity GetBookById(string isbn);
        void AddBook(Entity entity);
        void UpdateBook(Entity entity);
        void DeleteBook(Entity entity);
    }
}
