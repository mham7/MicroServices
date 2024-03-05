using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using ProductService.Interfaces.Repositories;
using ProductService.Model;

namespace ProductService.Features.Product.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Productt>
    {
        private readonly IProductRepository _product;
        private readonly IGenericRepository<Productt> _gen;
        private readonly IMapper _mapper;
     
        public UpdateProductHandler(IProductRepository product, IGenericRepository<Productt> gen,IMapper mapper)
        {
            _product = product;
            _gen = gen;
            _mapper = mapper;
            
        }
        public async Task<Productt> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            return await _product.Put(request.product);
        
            
        }
    }
}
