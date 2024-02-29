using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Interfaces;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> Post(ProductDto dto)
        {

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(int id)
        {
            Product product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product> Put(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
