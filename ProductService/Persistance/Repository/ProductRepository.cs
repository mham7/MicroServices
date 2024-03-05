using Microsoft.EntityFrameworkCore;
using ProductService.Persistance;
using ProductService.Interfaces.Repositories;
using ProductService.Model;
using ProductService.Model.Dto;
using ProductService.Persistance.Context;

namespace ProductService.Persistance.Repository
{
    public class ProductRepository : GenericRepository<Productt>, IProductRepository
    {
        public ProductRepository(ProductsContext context) : base(context)
        {
        }
    }
}
