using MediatR;
using ProductService.Interfaces.Repositories;
using ProductService.Model;

namespace ProductService.Features.Product.Query.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, List<Productt>>
    {
        private readonly IProductRepository _product;
        public GetAllProductHandler(IProductRepository product)
        {
            _product = product;
        }


        public async Task<List<Productt>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _product.GetAll();
        }
    }
}
