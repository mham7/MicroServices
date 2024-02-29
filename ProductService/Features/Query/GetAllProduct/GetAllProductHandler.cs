using MediatR;
using ProductService.Interfaces;
using ProductService.Model;

namespace ProductService.Features.Query.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand,List<Product>>
    {
        private readonly IProductRepository _product;
        public GetAllProductHandler(IProductRepository product)
        {
            _product = product;
        }
       

      public async Task<List<Product>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
            return await _product.GetAll();
        }
    }
}
