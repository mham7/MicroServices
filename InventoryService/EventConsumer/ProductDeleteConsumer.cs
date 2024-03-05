using Contracts.ProductEvents;
using InventoryService.Interfaces;
using InventoryService.Model;
using MassTransit;
using System.Diagnostics;
using System.Linq.Expressions;

namespace InventoryService.EventConsumer
{
    public class ProductDeleteConsumer:IConsumer<ProductDeleteEvent>
    {
        private readonly IIventoryRepository _iven;
        public ProductDeleteConsumer(IIventoryRepository iven)
        {

            _iven = iven;
        }
      

        public async Task Consume(ConsumeContext<ProductDeleteEvent> context)
        {
            int pid = context.Message.ProductId;
            Expression<Func<Inventory, bool>> predicate = item => item.ProductId == pid;
            Inventory inven = await _iven.Get(predicate);
            if(inven!=null) {
                await _iven.Delete(inven.InventoryHistoryId);
            }
            
        }
    }

}
