using Microsoft.EntityFrameworkCore;

namespace TestAdminCRUD.Data
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext() { }
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
