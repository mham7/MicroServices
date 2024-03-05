using Microsoft.EntityFrameworkCore;
using ProductService.Model;

namespace ProductService.Persistance
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Products;Trusted_Connection=true;MultipleActiveResultSets=True; TrustServerCertificate=true;");
        }

        public DbSet<Product> Product{ get; set; }
    }
}
