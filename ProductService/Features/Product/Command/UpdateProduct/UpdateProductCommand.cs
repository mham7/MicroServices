using MediatR;
using ProductService.Model;

namespace ProductService.Features.Product.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Productt>
    {
        public UpdateProductCommand(Productt product)
        {
            this.product = product;
        }

        public Productt product { get; set; }
    }
}
