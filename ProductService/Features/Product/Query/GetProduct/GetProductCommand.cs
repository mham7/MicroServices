using MediatR;
using ProductService.Model;

namespace ProductService.Features.Product.Query.GetProduct
{
    public class GetProductCommand : IRequest<Productt>
    {
        public GetProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
