using MediatR;
using ProductService.Model;

namespace ProductService.Features.Command.DeletProduct
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
