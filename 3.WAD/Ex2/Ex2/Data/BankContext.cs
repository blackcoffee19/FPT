using Microsoft.EntityFrameworkCore;

namespace Ex2.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options): base(options) { }
        public DbSet<People> People { get; set; }
    }
}
