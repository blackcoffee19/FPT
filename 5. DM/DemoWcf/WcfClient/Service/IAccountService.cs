using WcfClient.Models;

namespace WcfClient.Service
{
    public interface IAccountService
    {
        public Task<List<AccountDto>?> FindAll();
        public Task<AccountDto?> FindById(int id);
        public Task<AccountDto?> Login(string username, string password);
        public Task<int?> Create(AccountDto acc);
    }
}
