using Books.Application.Presistance;
using Books.Infrastructer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Books.Infrastructer.Services
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private ApplicationDbcontext context;

        public GenericRepository(ApplicationDbcontext context)
        {
            this.context = context;
        }

      
        public void AddBook(Entity entity)
        {
          context.Set<Entity>().Add(entity);
        }

        public void DeleteBook(Entity entity)
        {
          context.Set<Entity>().Remove(entity);
        }
        public void UpdateBook(Entity entity)
        {
            context.Set<Entity>().Update(entity);
        }

        public async Task<List<Entity>> GetAllBooks()
        {
            return await context.Set<Entity>().ToListAsync();
        }

        public Entity GetBookById(string isbn)
        {
            return context.Set<Entity>().Find(isbn);
        }
    }
}
