using MediatR;
using ProductService.Interfaces;
using ProductService.Model;

namespace ProductService.Features.Query.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, Product>
    {
        private readonly IProductRepository _product;
        public GetProductHandler(IProductRepository product)
        {
            _product = product;
        }
        public async Task<Product> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            return await _product.Get(request.Id);
        }
    }
}
