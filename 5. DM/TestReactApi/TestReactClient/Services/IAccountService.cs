using TestReactClient.Models;

namespace TestReactClient.Services
{
    public interface IAccountService
    {
        public Task<Account?> CheckLogin(string email, string password);
        public Task<List<Account>?> ListAccount(string? search);
        public Task<Account?> FindById(int id);
        public Task<bool> Update(Account account);
        public Task<bool> Delete(int id);
    }
}
