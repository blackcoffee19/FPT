using Microsoft.EntityFrameworkCore;

namespace Ex3.Models
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
