using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.CreateInventory
{
    public class CreateInventoryHandler : IRequestHandler<CreateInventory, Inventory>
    {
        private readonly IIventoryRepository _IvenRepo;
        public CreateInventoryHandler(IIventoryRepository IvenRepo)
        {
            _IvenRepo = IvenRepo; 
        }
        public async Task<Inventory> Handle(CreateInventory request, CancellationToken cancellationToken)
        {
           return await _IvenRepo.Post(request.inventory);
        }
    }
}
