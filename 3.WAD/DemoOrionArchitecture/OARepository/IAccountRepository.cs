using OA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public interface IAccountRepository
    {
        Task<List<Account>> FindAll();
        Task<Account?> FindById(int id);
        Task<int> Create(Account acc);
        Task Update(Account acc);
        Task Delete(int id);
    }
}
