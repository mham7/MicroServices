using MediatR;
using ProductService.Interfaces.Repositories;
using ProductService.Model;

namespace ProductService.Features.Product.Query.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, Productt>
    {
        private readonly IProductRepository _product;
        public GetProductHandler(IProductRepository product)
        {
            _product = product;
        }
        public async Task<Productt> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _product.Get(request.Id);
        }
    }
}
