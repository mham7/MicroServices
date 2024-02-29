using Contracts;
using InventoryService.Interfaces;
using InventoryService.Model;
using MassTransit;
using System.Diagnostics;

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
            Inventory inven = new Inventory()
            {
                ProductId = context.Message.ProductId,
                ChangeDate=DateTime.Now,
                QuantityChange=context.Message.Stock,
            };
            
            Debug.WriteLine(context.Message.ProductId);
            await _iven.Post(inven);
        }
    }
}
