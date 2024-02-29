using MediatR;
using ProductService.Model;

namespace ProductService.Features.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public UpdateProductCommand(Product product)
        {
            this.product = product;
        }

        public Product product { get; set; }
    }
}
