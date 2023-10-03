using Microsoft.EntityFrameworkCore;

namespace Ex1.Data
{
    public class NewsDbContext :DbContext
    {
        public NewsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<News>? News {  get; set; }  
    }
}
