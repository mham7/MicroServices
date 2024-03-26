using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using Polly;
using ProductService.Interfaces.Repositories;
using ProductService.Interfaces.Services.Utilities;
using ProductService.Model;
using ProductService.Model.Dto.Product;

namespace ProductService.Features.Product.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Productt>
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Productt> _gen;
        private readonly IBlobService _blobService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IAsyncPolicy _retry;
        public CreateProductHandler(IProductRepository product, IMapper mapper,IBlobService blobService,
            IGenericRepository<Productt> gen,IPublishEndpoint publishEndpoint)
        {
            _gen = gen;
            _product = product;
            _mapper = mapper;
            _blobService = blobService;
            _publishEndpoint = publishEndpoint;
            _retry = RetryPolicy.GetRetryPolicy();
        }
        public async Task<Productt> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto product = _mapper.Map<ProductDto>(request.Product);
            var retry = RetryPolicy.GetRetryPolicy();
            await  retry.ExecuteAsync(async () =>
            {
                product.ImageUrl = await _blobService.Post(request.Product.file);
            });
            Productt p = _mapper.Map<Productt>(product);
            Productt result= await _gen.Put(p);
            ProductCreatedEvent addevent = _mapper.Map<ProductCreatedEvent>(result);
            await retry.ExecuteAsync(async () =>
            {
                await _publishEndpoint.Publish<ProductCreatedEvent>(addevent);
            });
            return result;
        }
    }
}
