using CustomerService.Interfaces.Repositories;
using CustomerService.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CustomerContext _context;
        public GenericRepository(CustomerContext context)
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
