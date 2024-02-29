using MediatR;
using ProductService.Interfaces;
using ProductService.Model;

namespace ProductService.Features.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _product;
        public UpdateProductHandler(IProductRepository product)
        {
            _product = product;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _product.Put(request.product);
        }
    }
}
