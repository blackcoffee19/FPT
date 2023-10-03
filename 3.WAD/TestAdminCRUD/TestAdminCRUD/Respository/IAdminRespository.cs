using TestAdminCRUD.Models;

namespace TestAdminCRUD.Respository
{
    public interface IAdminRespository
    {
        Task<IEnumerable<AccountModel>?> ListAccounts();
        Task<AccountModel> Login(string email, string password);
        Task<AccountModel> Signup(AccountModel model);
    }
}
