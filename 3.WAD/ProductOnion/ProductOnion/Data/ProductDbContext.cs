using Microsoft.EntityFrameworkCore;

namespace ProductOnion.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext (DbContextOptions<ProductDbContext> options): base(options) { }
        public DbSet<Product>? Products { get; set; }
    }
}
