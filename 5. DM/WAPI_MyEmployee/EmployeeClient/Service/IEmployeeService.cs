using EmployeeClient.Models;

namespace EmployeeClient.Service
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>?> ListAll();
        public Task<EmployeeDto?> FindEmployee(string id);
        public Task<bool> Update(string id, EmployeeDto emp);
        public Task<string?> Create(EmployeeDto emp);
    
    }
}
