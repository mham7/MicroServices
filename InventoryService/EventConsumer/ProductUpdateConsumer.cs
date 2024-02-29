using Contracts;
using InventoryService.Interfaces;
using MassTransit;

namespace InventoryService.EventConsumer
{
    public class ProductUpdateConsumer : IConsumer<ProductUpdatedEvent>
    {
        private readonly IIventoryRepository _iven;
        public ProductUpdateConsumer(IIventoryRepository iven)
        {

            _iven = iven;
        }

        public Task Consume(ConsumeContext<ProductUpdatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
