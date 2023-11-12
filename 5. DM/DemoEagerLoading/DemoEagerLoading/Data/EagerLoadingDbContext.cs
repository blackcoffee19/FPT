using Microsoft.EntityFrameworkCore;

namespace DemoEagerLoading.Data
{
    public class EagerLoadingDbContext : DbContext
    {
        public EagerLoadingDbContext(DbContextOptions options): base(options) { }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
