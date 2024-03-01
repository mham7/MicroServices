using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Query.GetInventory
{
    public class GetInventoryHandler : IRequestHandler<GetInventory, Inventory>
    {
        private readonly IIventoryRepository _repository;
        public GetInventoryHandler(IIventoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Inventory> Handle(GetInventory request, CancellationToken cancellationToken)
        {
           return await _repository.Get(request.Id);
        }
    }
}
