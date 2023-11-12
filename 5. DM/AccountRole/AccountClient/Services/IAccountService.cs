using AccountClient.Models;

namespace AccountClient.Services
{
    public interface IAccountService
    {
        public Task<AccountDto?> Login(string email, string password);
        public Task<List<AccountDto>?> List();
        public Task<bool> Create(AccountDto acc);
        public Task<bool> Update(string email, AccountDto acc);
        public Task<AccountDto?> Detail(string email);
        public Task<bool> Delete(AccountDto acc);
    }
}
