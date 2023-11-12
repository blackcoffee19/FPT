using DemoWcf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DemoWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {
        DemoWcfEntities ctx = new DemoWcfEntities();    
        public async Task<List<AccountContract>> FindAll()
        {
            return await ctx.Accounts.Select(a=>new AccountContract { Id = a.Id, Email=a.Email,Fullname = a.Fullname}).ToListAsync();
        }
        public async Task<AccountContract> FindById(string strid)
        {
            int id = Convert.ToInt32(strid);
            var acc = await ctx.Accounts.FirstOrDefaultAsync(x=>x.Id==id);
            if (acc == null) { return null; }
            return new AccountContract { Id = acc.Id, Email = acc.Email, Fullname = acc.Fullname };
        }
        public async Task<AccountContract> Login(string email, string password)
        {
            var acc = await ctx.Accounts.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            if (acc == null) { return null; }
            return new AccountContract { Id = acc.Id, Email = acc.Email, Fullname = acc.Fullname };
        }
        public async Task<int> Create(AccountContract acc)
        {
            Account account = new Account { 
                Email = acc.Email,
                Password = acc.Password,
                Fullname = acc.Fullname
            };
            ctx.Accounts.Add(account);
            await ctx.SaveChangesAsync();
            return acc.Id;
        }
    }
}
