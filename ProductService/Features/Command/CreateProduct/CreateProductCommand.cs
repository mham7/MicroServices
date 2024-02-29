using MediatR;
using ProductService.Model;
using ProductService.Model.Dto;

namespace ProductService.Features.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<Product>
    {
        public CreateProductCommand(ProductDto product)
        {
            Product = product;
        }

        public ProductDto Product { get; set; }
    }
}
