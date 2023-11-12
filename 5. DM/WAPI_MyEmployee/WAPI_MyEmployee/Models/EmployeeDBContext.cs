using Microsoft.EntityFrameworkCore;

namespace WAPI_MyEmployee.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options): base(options) { }
        public DbSet<Employee>? Employees { get; set;}
    }
}
