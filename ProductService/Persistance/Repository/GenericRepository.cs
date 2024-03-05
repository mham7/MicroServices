using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces.Repositories;
using ProductService.Persistance.Context;

namespace ProductService.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ProductsContext _context;
        public GenericRepository(ProductsContext context)
        {
            _context = context; 
        }
        public async Task<T> Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
            await SaveChanges();
            return entity;
         
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Post(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;

        }

        public async Task<T> Put(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
