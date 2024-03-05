using MediatR;
using ProductService.Model;

namespace ProductService.Features.Product.Query.GetAllProduct
{
    public class GetAllProductCommand : IRequest<List<Productt>>
    {

    }
}
