using OA.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class AccountRespository: IAccountRepository
    {
        DemoOADbContext ctx;
        public AccountRespository(DemoOADbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<List<Account>> FindAll()
        {
            return await ctx.Accounts.ToListAsync();
        }
        public async Task<Account?> FindById(int id)
        {
            return await ctx.Accounts!.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Create(Account acc)
        {
            ctx.Accounts!.Add(acc);
            await ctx.SaveChangesAsync();
            return acc.Id;
        }
        public async Task Update (Account acc)
        {
            ctx.Entry(acc).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Account? acc = await FindById(id);
            if(acc != null)
            {
                ctx.Accounts!.Remove(acc);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
