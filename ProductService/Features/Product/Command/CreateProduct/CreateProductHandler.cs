using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using ProductService.Interfaces.Repositories;
using ProductService.Interfaces.Services.Utilities;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Features.Product.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Productt>
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Productt> _gen;
        private readonly IBlobService _blobService;
        private readonly IPublishEndpoint _publishEndpoint;
        public CreateProductHandler(IProductRepository product, IMapper mapper,IBlobService blobService,
            IGenericRepository<Productt> gen,IPublishEndpoint publishEndpoint)
        {
            _gen = gen;
            _product = product;
            _mapper = mapper;
            _blobService = blobService;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<Productt> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto product = _mapper.Map<ProductDto>(request.Product);
            product.ImageUrl = await _blobService.Post(request.Product.file);
            Productt p = _mapper.Map<Productt>(product);
            Productt result= await _gen.Put(p);
            ProductCreatedEvent addevent = _mapper.Map<ProductCreatedEvent>(result);
            await _publishEndpoint.Publish<ProductCreatedEvent>(addevent);
            return result;
        }
    }
}
