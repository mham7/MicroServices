using InventoryService.Model;
using MediatR;
using System.Linq.Expressions;

namespace InventoryService.Features.Query.GetInventoryByFilter
{
    public class GetInventoryByFilter : IRequest<Inventory>
    {
        public GetInventoryByFilter(Expression<Func<Inventory, bool>> Filter)
        {
            this.Filter = Filter;
        }
        public Expression<Func<Inventory, bool>> Filter { get; set; }
    }
}
