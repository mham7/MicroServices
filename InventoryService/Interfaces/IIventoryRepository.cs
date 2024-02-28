using InventoryService.Model;

namespace InventoryService.Interfaces
{
    public interface IIventoryRepository
    {
        Task<Inventory> Get(int id);
        Task<List<Inventory>> GetAll();
        Task<Inventory> Post(Inventory a);
        Task<Inventory> Delete(int id);
        Task<Inventory> Put(Inventory inventory);
    }
}
