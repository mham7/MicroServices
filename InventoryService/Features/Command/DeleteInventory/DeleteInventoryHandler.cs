using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.DeleteInventory
{
    public class DeleteInventoryHandler : IRequestHandler<DeleteInventory, Inventory>
    {
        private readonly IIventoryRepository _InvenRepo;
        public DeleteInventoryHandler(IIventoryRepository IvenRepo)
        {
            _InvenRepo = IvenRepo;
        }
        public async Task<Inventory> Handle(DeleteInventory request, CancellationToken cancellationToken)
        {
            return await _InvenRepo.Delete(request.Id);
        }
    }
}
