using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.CreateInventory
{
    public class CreateInventory : IRequest<Inventory>
    {
        public CreateInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
        public Inventory inventory { get; set; }
    }
}
