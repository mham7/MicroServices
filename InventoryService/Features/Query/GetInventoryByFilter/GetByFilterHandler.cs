using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Query.GetInventoryByFilter
{
    public class GetByFilterHandler : IRequestHandler<GetInventoryByFilter, Inventory> { 
        private readonly IIventoryRepository _Iven;
        public GetByFilterHandler(IIventoryRepository Iven)
        {
            _Iven = Iven;
        }
        public async Task<Inventory> Handle(GetInventoryByFilter request, CancellationToken cancellationToken)
        {
            return await _Iven.Get(request.Filter);
        }
    }
}
