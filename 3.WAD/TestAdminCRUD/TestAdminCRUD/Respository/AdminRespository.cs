using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAdminCRUD.Data;
using TestAdminCRUD.Models;

namespace TestAdminCRUD.Respository
{
    public class AdminRespository : IAdminRespository
    {
        AdminDbContext ctx;
        public AdminRespository(AdminDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<AccountModel> Login(string email, string password)
        {
            List<Account>? accs = await ctx.Accounts.ToListAsync();
            Account acc = accs.Where(e => e.Email == email).FirstOrDefault();
            if (acc != null)
            {
                IPasswordHasher<Account> asc = new PasswordHasher<Account>();
                var check = asc.VerifyHashedPassword(acc, acc.Password, password);

                if (check.ToString() == "Success") { 
                    return new AccountModel { Id = acc.Id, Email = acc.Email, Password = acc.Password, Role = acc.Role, Image = acc.Image, Name = acc.Name };
                }
            }
            return null;
        }
        public async Task<AccountModel> Signup(AccountModel model)
        {
            Account acc = new Account { Name = model.Name, Email = model.Email, Role = model.Role, Image = model.Image };
            try
            {
                IPasswordHasher<Account> accHa = new PasswordHasher<Account>();
                string str = accHa.HashPassword(acc, model.Password);
                acc.Password = str;
                ctx.Accounts.Add(acc);
                await ctx.SaveChangesAsync();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
            return model;
        }

        public async Task<IEnumerable<AccountModel>?> ListAccounts()
        {
            List<Account>? account = await ctx.Accounts.ToListAsync();
            List<AccountModel> acc = new List<AccountModel>();
            foreach (Account ac in account)
            {
                acc.Add(new AccountModel { Id = ac.Id, Email = ac.Email, Password = ac.Password, Image = ac.Image, Role = ac.Role,Name=ac.Name });
            }
            return acc;
        }

    }
}
