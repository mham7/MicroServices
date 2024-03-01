using Contracts;
using MassTransit;
using MediatR;
using ProductService.Features.Command.CreateProduct;
using ProductService.Features.Command.DeletProduct;
using ProductService.Features.Command.UpdateProduct;
using ProductService.Features.Query.GetAllProduct;
using ProductService.Features.Query.GetProduct;
using ProductService.Interfaces;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Service
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductLogic(IProductRepository repository,IMediator mediator,IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _repository = repository;
            _publishEndpoint=publishEndpoint;
        }
        public async Task Delete(int id)
        {
            
            await _mediator.Send(new DeleteProductCommand(id));

        }

        public async Task<Product> Get(int id)
        {
            return await _mediator.Send(new GetProductCommand(id));
        }

        public async Task<List<Product>> GetAll()
        {
            return await _mediator.Send(new GetAllProductCommand());
        }

        public async Task<Product> Post(ProductDto product)
        {
            
            Product p=await _mediator.Send(new CreateProductCommand(product));
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

        public async Task<Product> Put(Product product)
        {
            Product p= await _mediator.Send(new UpdateProductCommand(product));
            await _publishEndpoint.Publish<ProductUpdatedEvent>(new
            {
                p.ProductId,
                p.Name,
                p.Price,
                p.Description,
                p.Stock,
            });
            return p;
        }
    }
}
