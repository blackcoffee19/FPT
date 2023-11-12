using EmployeeClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeClient.Service
{
    public class EmployeeService : IEmployeeService
    {
        HttpClient client;
        public const string BASE_ADD = "http://localhost:5263/api/Employee";
        public EmployeeService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<EmployeeDto>?> ListAll() {
            string url = $"{BASE_ADD}/list";
            var res = await client.GetAsync(url);
            List<EmployeeDto>? list = null;
            if (res != null)
            {
                var str = await res.Content.ReadAsStringAsync();
                list= JsonConvert.DeserializeObject<List<EmployeeDto>>(str); 
            }
            return list;
        }
        public async Task<EmployeeDto?> FindEmployee(string id)
        {
            string url = $"{BASE_ADD}/{id}";
            var res = await client.GetAsync(url);
            EmployeeDto? emp = null;
            if(res.IsSuccessStatusCode)
            {
                var sr = await res.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<EmployeeDto>(sr);
            }
            return emp;
        }
        public async Task<bool> Update(string id,EmployeeDto emp)
        {
            string url = $"{BASE_ADD}/{id}";
            bool result = false;
            string str = JsonConvert.SerializeObject(emp);
            var ss= new StringContent(str, Encoding.UTF8, "application/json");
            var res  = await client.PutAsync(url,ss);
            if (res.IsSuccessStatusCode)
            {
                var sts= await res.Content.ReadAsStringAsync();
                result= Convert.ToBoolean(sts);
            }
            return result;
        }
        public async Task<string?> Create(EmployeeDto emp)
        {
            string url = $"{BASE_ADD}/create";
            string json = JsonConvert.SerializeObject(emp);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);
            string? result = null;
            if(res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadAsStringAsync();
            }
            Console.WriteLine(result);
            return result;
        }
    }
}
