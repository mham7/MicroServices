using Contracts.ProductEvents;
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
            if (inven != null)
            {
                inven.QuantityChange = inven.QuantityChange + context.Message.QuantityChange;
                inven.ChangeDate = DateTime.Now;
                await _iven.Put(inven);
            }
            


        }
    }
}
