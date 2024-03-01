using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Query.GetInventory
{
    public class GetInventory : IRequest<Inventory>
    {
        public GetInventory(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
