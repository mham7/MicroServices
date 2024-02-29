using MediatR;
using ProductService.Model;

namespace ProductService.Features.Query.GetAllProduct
{
    public class GetAllProductCommand : IRequest<List<Product>>
    {

    }
}
