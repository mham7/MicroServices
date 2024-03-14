using MediatR;
using ProductService.Features.Generic.Query.GetAllCommandHandler;
using ProductService.Interfaces.Repositories;
using ProductService.Model;

namespace ProductService.Features.Product.Query.GetAllProduct
{
    public class GetAllProductHandler : GetAllCommandHandler<List<Productt>>

    {
        public GetAllProductHandler(IGenericRepository<List<Productt>> gen) : base(gen)
        {
        }
    }
}
