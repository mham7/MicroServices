using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.UpdateInventory
{
    public class UpdateInventoryHandler : IRequestHandler<UpdateInventory, Inventory>
    {
        private readonly IIventoryRepository _IvenRepo;
        public UpdateInventoryHandler(IIventoryRepository IvenRepo)
        {
            _IvenRepo = IvenRepo;
        }
        public async Task<Inventory> Handle(UpdateInventory request, CancellationToken cancellationToken)
        {
            return await _IvenRepo.Put(request.Inventory);
        }
    }
}
