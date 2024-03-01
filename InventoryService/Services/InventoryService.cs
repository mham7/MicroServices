using InventoryService.Features.Command.CreateInventory;
using InventoryService.Features.Command.DeleteInventory;
using InventoryService.Features.Command.UpdateInventory;
using InventoryService.Features.Query.GetInventory;
using InventoryService.Features.Query.GetInventoryByFilter;
using InventoryService.Features.Query.GetInventoryList;
using InventoryService.Interfaces;
using InventoryService.Model;
using MediatR;
using System.Linq.Expressions;

namespace InventoryService.Services
{
    public class InventoryService:IInventoryService
    {
        private readonly IMediator _mediator;
        public InventoryService(IMediator mediator) { _mediator = mediator; }

        public async Task<Inventory> Delete(int Id)
        {
            return await _mediator.Send(new DeleteInventory(Id));
        }

        public async Task<Inventory> Get(int Id)
        {
            return await _mediator.Send(new GetInventory(Id));
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _mediator.Send(new GetInventoryList());
        }

        public async Task<Inventory> Post(Inventory inventory)
        {
            return await _mediator.Send(new CreateInventory(inventory));
        }

        public async Task<Inventory> Put(Inventory inventory)
        {
            return await _mediator.Send(new UpdateInventory(inventory));
        }
        public async Task<Inventory> Get(Expression<Func<Inventory,bool>> predicate)
        {
            return await _mediator.Send(new GetInventoryByFilter(predicate));
        }
    }
}
