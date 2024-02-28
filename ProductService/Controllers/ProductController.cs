using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _product;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductController(IProductLogic product,IPublishEndpoint publishEndpoint)
        {
            _product=product;
            _publishEndpoint=publishEndpoint;
        }
        [HttpGet("Get")]
       public async Task<Product> Get(int id)
        {
            return await _product.Get( id);
        }

        [HttpGet("GetAll")]
        public async Task<List<Product>> Get()
        {
            return await _product.GetAll();
        }

        [HttpPost("Add")]
        public async Task<Product> Post(ProductDto dto)
        {
            Product p = await _product.Post(dto);
            
            await _publishEndpoint.Publish<ProductCreatedEvent>(new
            {
                p.ProductId,
                p.Name,
                p.Price,
                p.Description,
                p.Stock,  
            });
            return p;
        }

        [HttpPut("Update")]

        public async Task<Product> Put(Product p)
        {
            return await _product.Put(p);
        }

    }
}
