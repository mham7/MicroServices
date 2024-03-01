using InventoryService.Model;

namespace InventoryService.Interfaces
{
    public interface IInventoryService
    { 
       
     Task<Inventory> Post(Inventory inventory);
     Task<Inventory> Put(Inventory inventory);
     Task<Inventory> Delete(int Id);
     Task<Inventory> Get(int Id);
     Task<List<Inventory>> GetAll();



    }
}
