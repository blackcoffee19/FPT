using OA.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class DemoOADbContext : DbContext
    {
        public DemoOADbContext(DbContextOptions options) :base(options){ 
        }
        public DbSet<Account>? Accounts { get; set; }
    }
}
