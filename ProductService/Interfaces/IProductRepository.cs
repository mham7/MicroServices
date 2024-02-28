using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<List<Product>> GetAll();
        Task<Product> Post(ProductDto dto);
        Task Delete(int id);
        Task<Product> Put(Product product);

    }
}
