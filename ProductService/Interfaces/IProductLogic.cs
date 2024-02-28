using ProductService.Model.Dto;
using ProductService.Model;

namespace ProductService.Interfaces
{
    public interface IProductLogic
    {
        Task<Product> Get(int id);
        Task<List<Product>> GetAll();
        Task<Product> Post(ProductDto dto);
        Task Delete(int id);
        Task<Product> Put(Product product);
    }
}
