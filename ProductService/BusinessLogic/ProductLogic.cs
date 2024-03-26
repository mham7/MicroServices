using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using ProductService.Features.Product.Command.CreateProduct;
using ProductService.Features.Product.Command.DeletProduct;
using ProductService.Features.Product.Command.UpdateProduct;
using ProductService.Features.Product.Query.GetAllProduct;
using ProductService.Features.Product.Query.GetProduct;
using ProductService.Interfaces.Repositories;
using ProductService.Interfaces.Services;
using ProductService.Interfaces.Services.Utilities;
using ProductService.Model;
using ProductService.Model.Dto.Product;

namespace ProductService.Service
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;
        public ProductLogic(IProductRepository repository,IMediator mediator,IPublishEndpoint publishEndpoint,IBlobService blobService,IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _publishEndpoint=publishEndpoint;
            _blobService = blobService;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            
            //await _mediator.Send(new DeleteProductCommand(id));

        }

        public async Task<Productt> Get(int id)
        {
            return await _mediator.Send(new GetProductCommand(id));
        }

        public async Task<List<Productt>> GetAll()
        {
            return await _mediator.Send(new GetAllProductCommand());
        }

        public async Task<Productt> Post(AddProductDto dto)
        {
            ProductDto product = _mapper.Map<ProductDto>(dto);
            product.ImageUrl = await _blobService.Post(dto.file);
            Productt p=await _mediator.Send(new CreateProductCommand(dto));
            ProductCreatedEvent addevent=_mapper.Map<ProductCreatedEvent>(p);
            await _publishEndpoint.Publish<ProductCreatedEvent>(addevent);
            return p;

            }

        public async Task<Productt> Put(Productt product)
        {
            Productt p= await _mediator.Send(new UpdateProductCommand(product));
            var retry = RetryPolicy.GetRetryPolicy();
            retry.ExecuteAsync(async () =>
            {
                await _publishEndpoint.Publish<ProductUpdatedEvent>(new
                {
                    p.ProductId,
                    p.Name,
                    p.Price,
                    p.Description,

                });
            });
            return p;
        }
    }
}
