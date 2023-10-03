using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Models
{
    public class DemoRazorDbContext: DbContext
    {
        public DemoRazorDbContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
