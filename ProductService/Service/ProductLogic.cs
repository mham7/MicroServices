using ProductService.Interfaces;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Service
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _repository;
        public ProductLogic(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> Post(ProductDto dto)
        {
            return await _repository.Post(dto);
        }

        public async Task<Product> Put(Product product)
        {
            return await _repository.Put(product);
        }
    }
}
