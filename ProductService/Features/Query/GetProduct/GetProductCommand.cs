using MediatR;
using ProductService.Model;

namespace ProductService.Features.Query.GetProduct
{
    public class GetProductCommand : IRequest<Product>
    {
        public GetProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
