using TestClient.Models;

namespace TestClient.Services
{
    public interface IAccountService
    {
        public Task<AccountDto?> CheckLogin(string email, string password);
        public Task<List<AccountDto>?> ListAccount(string? search);
        public Task<AccountDto?> FindById(int id);
        public Task<bool> Update(int id,AccountDto account);
        public Task<bool> Delete(int id);
        public Task<bool> CheckAdmin(int id);
        public Task<string?> Create(AccountDto account);
    }
}
