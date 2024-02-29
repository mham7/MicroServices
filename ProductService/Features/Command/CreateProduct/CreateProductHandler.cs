using MediatR;
using ProductService.Interfaces;
using ProductService.Model;

namespace ProductService.Features.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand,Product>
    {
        private readonly IProductRepository _product;
        public CreateProductHandler(IProductRepository product)
        {
            _product=product;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _product.Post(request.Product);
        }
    }
}
