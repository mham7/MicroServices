using Contracts.ProductEvents;
using InventoryService.Interfaces;
using InventoryService.Model;
using MassTransit;
using System.Diagnostics;
using System.Linq.Expressions;

namespace InventoryService.NewFolder
{
    public sealed class ProductCreatedConsumer : IConsumer<ProductCreatedEvent>
    {
        
        private readonly IIventoryRepository _iven;
        public ProductCreatedConsumer(IIventoryRepository iven)
        {
            
            _iven= iven;
        }
        public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            Expression<Func<Inventory, bool>> filter = inventory => inventory.ProductId == context.Message.ProductId;
            Inventory iven = await _iven.Get(filter);
            if (iven == null)
            {
                Inventory inven1 = new Inventory()
                {
                    ProductId = context.Message.ProductId,
                    ChangeDate = DateTime.Now,
                    QuantityChange = 1,
                };
                await _iven.Post(inven1);
            }
           
            
            
        }
    }
}
