using MediatR;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Features.Product.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<Productt>
    {
        public CreateProductCommand(AddProductDto product)
        {
            Product = product;
        }

        public AddProductDto Product { get; set; }
    }
}
