using MediatR;
using ProductService.Model;

namespace ProductService.Features.Product.Command.DeletProduct
{
    public class DeleteProductCommand : IRequest<Productt>
    {
        public DeleteProductCommand(Productt productt)
        {
            this.product=productt;
        }

        public Productt product { get; set; }
    }
}
