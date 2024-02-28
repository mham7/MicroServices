using InventoryService.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= .\\SQLEXPRESS;Database=Inventory;Trusted_Connection=true;MultipleActiveResultSets=True; TrustServerCertificate=true; ");
        }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
