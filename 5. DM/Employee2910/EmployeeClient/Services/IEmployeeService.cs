using EmployeeClient.Models;

namespace EmployeeClient.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>?> FindAll();
        public Task<EmployeeDto?> FindById(string id);
        public Task<List<EmployeeDto>?> Search(string name);
        public Task<EmployeeDto?> Create(EmployeeDto em);
        public Task<bool> Update(string id, EmployeeDto em);
        public Task<bool> Delete(string id);
        public Task<EmployeeDto?> Login(EmployLogin emp);
    }
}
