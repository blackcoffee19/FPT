using OA.Domain;
using OA.Repository;
using OA.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public class AccountService : IAccountService
    {
        IAccountRepository repo;
        public AccountService(IAccountRepository repo) {
            this.repo = repo;
        }
        public async Task<List<AccountDto>> FindAll()
        {
            List<Account> accounts = await repo.FindAll();
            return accounts.Select(x => new AccountDto { Id = x.Id, Email = x.Email, Phone = x.Phone }).ToList();
        }
        public async Task<AccountDto?> FindById(int id)
        {
            Account? account = await repo.FindById(id);
            if (account != null)
            {
                return new AccountDto { Id = account.Id, Email = account.Email, Phone = account.Phone };
            }
            else
            {
                return null;
            }
        }
        public async Task<int> Create (AccountDto acc)
        {
            Account a = new Account { Id = acc.Id, Email = acc.Email, Phone = acc.Phone, Password = acc.Password };
            return await repo.Create(a);
        }
        public async Task<AccountDto> Login(string email, string password)
        {
            List<Account>? acc = await repo.FindAll();
            var account = acc.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
            if (account != null)
            {
                return new AccountDto { Id = account.Id, Email = account.Email, Phone = account.Phone, Password = password };
            }
            return null;
        }
    }
}
