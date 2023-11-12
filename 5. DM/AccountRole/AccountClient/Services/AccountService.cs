using AccountClient.Models;
using Newtonsoft.Json;

namespace AccountClient.Services
{
    public class AccountService: IAccountService
    {
        HttpClient client;
        public const string BASE_URL = "http://localhost:5098/api/AccountApi";
        public AccountService (HttpClient client)
        {
            this.client = client;
        }
        public async Task<AccountDto?> Login(string email, string password)
        {
            string url = $"{BASE_URL}/login/{email}/{password}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccountDto>(result);
            }
            return null;
        }
        public async Task<List<AccountDto>?> List()
        {
            string url = $"{BASE_URL}/list";
            var res = await client.GetStringAsync(url);
            return res == null ? null : JsonConvert.DeserializeObject<List<AccountDto>>(res);
        }
        public async Task<bool> Create(AccountDto acc)
        {
            string url = $"{BASE_URL}/create";
            var json = JsonConvert.SerializeObject(acc);
            var content = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var response  = await client.PostAsync(url, content);
            bool create = false;
            if(response.IsSuccessStatusCode)
            {
                create = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            }
            return create;
        }
        public async Task<bool> Update(string email,AccountDto acc)
        {
            string url = $"{BASE_URL}/update/{email}";
            var json = JsonConvert.SerializeObject(acc);
            var content = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var response = await client.PostAsync(url,content); 
            bool update = false;
            if (response.IsSuccessStatusCode)
            {
                update = Convert.ToBoolean( await response.Content.ReadAsStringAsync());    
            }
            return update;
        }
        public async Task<AccountDto?> Detail (string email)
        {
            string url = $"{BASE_URL}/detail/{email}";
            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<AccountDto?>(response);
        } 
        public async Task<bool> Delete (AccountDto acc)
        {
            string url = $"{BASE_URL}/delete";
            var json = JsonConvert.SerializeObject(acc);
            var content = new StringContent(json,System.Text.Encoding.UTF8,"application/json"); 
            var response = await client.PostAsync(url,content);
            bool result = false;
            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                result = Convert.ToBoolean(res);
            }
            return result;
        }
    }
}
