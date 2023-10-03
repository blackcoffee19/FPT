using Microsoft.EntityFrameworkCore;

namespace Ex4.Models
{
    public class CustomersDbContext :DbContext
    {
        public CustomersDbContext(DbContextOptions options):base(options) { }   
        public DbSet<Customer> Customers { get; set;}
    }
}
