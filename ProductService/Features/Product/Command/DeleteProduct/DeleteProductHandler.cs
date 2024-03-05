using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using ProductService.Interfaces.Repositories;
using ProductService.Model;

namespace ProductService.Features.Product.Command.DeletProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Productt>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IGenericRepository<Productt> _genericRepository;
        private readonly IMapper _mapper;
        public DeleteProductHandler(IGenericRepository<Productt> genericRepository,IPublishEndpoint publishEndpoint,IMapper mapper)
        {
            _publishEndpoint=publishEndpoint;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Productt> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            
              Productt result= await _genericRepository.Delete(request.product);
              ProductDeleteEvent addevent = _mapper.Map<ProductDeleteEvent>(result);
            if (result != null)
            {
                await _publishEndpoint.Publish<ProductDeleteEvent>(addevent);
            }
              return result;
        }
    }
}
