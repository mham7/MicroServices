using InventoryService.Data;
using InventoryService.Interfaces;
using InventoryService.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repository
{
    public class InventoryRepository:IIventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<Inventory> Get(int id)
        {
            return await _context.Inventory.FindAsync(id);
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<Inventory> Post(Inventory dto)
        {

            

            _context.Inventory.Add(dto);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task Delete(int id)
        {
            Inventory Inventory = await _context.Inventory.FindAsync(id);
            if (Inventory != null)
            {
                _context.Inventory.Remove(Inventory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Inventory> Put(Inventory Inventory)
        {
            _context.Update(Inventory);
            await _context.SaveChangesAsync();

            return Inventory;
        }

        Task<Inventory> IIventoryRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
