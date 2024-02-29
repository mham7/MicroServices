using MediatR;
using ProductService.Interfaces;
using ProductService.Model;

namespace ProductService.Features.Command.DeletProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepository _product;
        public DeleteProductHandler(IProductRepository product)
        {
            _product = product;
        }
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _product.Delete(request.Id);
        }
    }
}
