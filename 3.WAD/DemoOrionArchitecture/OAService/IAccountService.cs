using OA.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public interface IAccountService
    {
        Task<List<AccountDto>> FindAll();
        Task<AccountDto?> FindById(int id);
        Task<int> Create(AccountDto acc);
        Task<AccountDto> Login(string email, string password);
    }
}
