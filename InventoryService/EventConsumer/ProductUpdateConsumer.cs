using Contracts;
using InventoryService.Interfaces;
using InventoryService.Model;
using MassTransit;
using System.Linq.Expressions;

namespace InventoryService.EventConsumer
{
    public class ProductUpdateConsumer : IConsumer<ProductUpdatedEvent>
    {
        private readonly IIventoryRepository _iven;
        public ProductUpdateConsumer(IIventoryRepository iven)
        {

            _iven = iven;
        }

        public async Task Consume(ConsumeContext<ProductUpdatedEvent> context)
        {
            int pid = context.Message.ProductId;
            Expression<Func<Inventory, bool>> predicate = item => item.ProductId == pid;
            Inventory inven = await _iven.Get(predicate);
            inven.QuantityChange = context.Message.Stock;
            await _iven.Put(inven);

            


        }
    }
}
