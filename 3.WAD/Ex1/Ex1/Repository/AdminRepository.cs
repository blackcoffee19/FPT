using Ex1.Data;
using Microsoft.EntityFrameworkCore;

namespace Ex1.Repository
{
    public class AdminRepository
    {
        NewsDbContext ctx;
        public AdminRepository(NewsDbContext ctx) { 
            this.ctx = ctx;
        }
        public async Task<bool> Login(string u, string p)
        {
            Admin? ad = await ctx.Admins!.SingleOrDefaultAsync(o=>o.Username==u && o.Password == p);
            return ad != null;
        }
    }
}
