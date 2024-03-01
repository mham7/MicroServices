using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Query.GetInventoryList
{
    public class GetInventoryList : IRequest<List<Inventory>>
    {

    }
}
