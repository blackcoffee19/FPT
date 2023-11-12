using EmployeeClient.Models;
using Newtonsoft.Json;

namespace EmployeeClient.Services
{
    public class EmployeeService : IEmployeeService
    {
        HttpClient client;
        public const string BASE_URL_API = "http://localhost:5005/api/EmployeeApi";
        public const string BASE_URL_WCF = "http://localhost:62061/EmployeeService.svc";
        public EmployeeService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<EmployeeDto>?> FindAll()
        {
            //string url = BASE_URL_API;
            //WCF Service
            string url = $"{BASE_URL_WCF}/api/employee";
            var res = await client.GetStringAsync(url);
            List<EmployeeDto>? result = JsonConvert.DeserializeObject<List<EmployeeDto>?>(res);  
            return result;
        }
        public async Task<EmployeeDto?> FindById(string id)
        {
            //string url = $"{BASE_URL_API}/detail/{id}";
            string url = $"{BASE_URL_WCF}/api/employee/detail/{id}";
            var resp = await client.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                var result = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                return JsonConvert.DeserializeObject<EmployeeDto>(result);
            }
            return null;
        }
        public async Task<List<EmployeeDto>?> Search(string name)
        {
            string url = $"{BASE_URL_API}/search/{name}";
            string resp = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<EmployeeDto>?>(resp);
        }
        public async Task<EmployeeDto?> Create(EmployeeDto em)
        {
            //string url = $"{BASE_URL_API}/create";
            string url = $"{BASE_URL_WCF}/api/employee/create";
            string json = JsonConvert.SerializeObject(em);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);
            if (res.IsSuccessStatusCode) { 
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeeDto>(result);
            }
            return null;
        }
        public async Task<bool> Update(string id,EmployeeDto em)
        {
            //string url = $"{BASE_URL_API}/update/{id}";
            string url = $"{BASE_URL_WCF}/api/employee/update";
            var json = JsonConvert.SerializeObject(em);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);
            bool result = false;
            if (res.IsSuccessStatusCode)
            {
                result = Convert.ToBoolean(await  res.Content.ReadAsStringAsync()); 
            }
            return Convert.ToBoolean(result);
        }
        public async Task<bool> Delete(string id)
        {
            //string url = $"{BASE_URL_API}/delete/{id}";
            string url = $"{BASE_URL_WCF}/api/employee/delete/{id}";
            //var res_api = await client.DeleteAsync(url);
            /*HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, url);*/
            var res_wcf = await client.DeleteAsync(url);
            if (res_wcf.IsSuccessStatusCode)
            {
                return Convert.ToBoolean(await res_wcf.Content.ReadAsStringAsync());
            }
            return false;
        }
        public async Task<EmployeeDto?> Login(EmployLogin emp)
        {
            //string url = $"{BASE_URL_API}/login/{emp.EmployeeId}/{emp.Password}";
            string url = $"{BASE_URL_WCF}/api/employee/login/{emp.EmployeeId}/{emp.Password}";
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, url);
            var res = await client.SendAsync(msg);
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeeDto>(result);
            }
            return null;
        }
    }
}
