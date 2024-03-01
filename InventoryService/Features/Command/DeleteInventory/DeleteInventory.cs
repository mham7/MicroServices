using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Command.DeleteInventory
{
    public class DeleteInventory : IRequest<Inventory>
    {
        public DeleteInventory(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
