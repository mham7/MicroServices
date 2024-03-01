using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.UpdateInventory
{
    public class UpdateInventory : IRequest<Inventory>
    {
        public UpdateInventory(Inventory Inventory)
        {
            this.Inventory = Inventory;
        }
        public Inventory Inventory { get; set; }
    }
}
