using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;

namespace InventoryService.Features.Query.GetInventoryList
{
    public class GetInventoryListHandler : IRequestHandler<GetInventoryList, List<Inventory>>
    {
        private readonly IIventoryRepository iventoryRepository;
        public GetInventoryListHandler(IIventoryRepository iventoryRepository)
        {
            this.iventoryRepository = iventoryRepository;
        }
        public async Task<List<Inventory>> Handle(GetInventoryList request, CancellationToken cancellationToken)
        {
            return await iventoryRepository.GetAll();
        }
    }
}
