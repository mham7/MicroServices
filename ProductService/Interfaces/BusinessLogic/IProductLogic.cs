using ProductService.Model;
using ProductService.Model.Dto.Product;

namespace ProductService.Interfaces.Services
{
    public interface IProductLogic
    {
        Task<Productt> Get(int id);
        Task<List<Productt>> GetAll();
        Task<Productt> Post(AddProductDto dto);
        Task Delete(int id);
        Task<Productt> Put(Productt product);
    }
}
