using Newtonsoft.Json;
using System.Text;
using WcfClient.Models;

namespace WcfClient.Service
{
    public class AccountService : IAccountService
    {
        HttpClient client;
        public const string BASE_ADDR = "http://localhost:59257/AccountService.svc/api";
        public AccountService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<AccountDto>?> FindAll()
        {
            string url = $"{BASE_ADDR}/account";
            var json = await client.GetStringAsync(url);
            var res = JsonConvert.DeserializeObject<List<AccountDto>>(json);
            return res;
        }
        public async Task<AccountDto?> FindById(int id)
        {
            string url = $"{BASE_ADDR}/account/{id}";
            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<AccountDto>(json);
        }
        public async Task<AccountDto?> Login(string username, string password)
        {
            string url = $"{BASE_ADDR}/account/{username}/{password}";
            /*var json = await client.GetStringAsync(url);*/
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, url);
            var res = await client.SendAsync(msg);
            if (res.IsSuccessStatusCode)
            {
                var jsn =await res.Content.ReadAsStringAsync();    
                return JsonConvert.DeserializeObject<AccountDto> (jsn);
            }
            return null;
        }
        public async Task<int?> Create(AccountDto acc)
        {
            string url = BASE_ADDR+ "/account";

            var json2 = await client.GetStringAsync(url);
            var res2 = JsonConvert.DeserializeObject<List<AccountDto>>(json2);
            acc.Id = res2.Count() + 1;
            string accJson = JsonConvert.SerializeObject(acc);
            var content = new StringContent(accJson, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url, content);
            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                return Convert.ToInt32(json);
            };
            Console.WriteLine(res);
            return null;
        }
    }
}
