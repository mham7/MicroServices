using Contracts;
using InventoryService.Interfaces;
using InventoryService.Model;
using MassTransit;
using System.Diagnostics;

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
            await _iven.Delete(context.Message.ProductId);
        }
    }

}
