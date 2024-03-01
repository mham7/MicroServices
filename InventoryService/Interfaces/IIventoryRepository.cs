using InventoryService.Model;
using System.Linq.Expressions;

namespace InventoryService.Interfaces
{
    public interface IIventoryRepository
    {
        Task<Inventory> Get(int id);
        Task<List<Inventory>> GetAll();
        Task<Inventory> Post(Inventory a);
        Task<Inventory> Delete(int id);
        Task<Inventory> Put(Inventory inventory);
        Task<Inventory> Get(Expression<Func<Inventory, bool>> filter);
    }
}
