using Newtonsoft.Json;
using TestClient.Models;

namespace TestClient.Services
{
    public class AccountService : IAccountService
    {
        HttpClient client;
        public const string BASE_URL = "http://localhost:5274/api/Account";
        public AccountService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<AccountDto?> CheckLogin(string email, string password)
        {
            string url = $"{BASE_URL}/login/{email}/{password}";

            var res = await client.GetStringAsync(url);
            if (res == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AccountDto>(res);
        }
        public async Task<List<AccountDto>?> ListAccount(string? search)
        {
            var url = search != null ? $"{BASE_URL}/list?search={search}" : $"{BASE_URL}/list";
            var res = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<AccountDto>>(res);
        }
        public async Task<AccountDto?> FindById(int id)
        {
            var url = $"{BASE_URL}/{id}";
            var res = await client.GetStringAsync(url);
            if (res == null) { return null; }
            return JsonConvert.DeserializeObject<AccountDto>(res);
        }
        public async Task<bool> Update(int id,AccountDto account)
        {
            var url = $"{BASE_URL}/update/{id}";
            //Chuyển Account thành chuỗi json 
            //Account reacc = new Account { Name=account.Name,Password=account.Password,Email=account.Email,Image=account.Image,Admin=(bool)account.Admin };
            string json = JsonConvert.SerializeObject(account);
            //tạo đối tượng HttpClient chưá chuỗi json
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url, content);
            if (res.IsSuccessStatusCode)
            {
                var resp = await res.Content.ReadAsStringAsync();
                if (resp == "true")
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public async Task<bool> Delete(int id)
        {
            var url = $"{BASE_URL}/{id}";
            var res = await client.DeleteAsync(url);
            if (res == null) { return false; };
            bool check = await res.Content.ReadAsStringAsync() == "true";
            return check;
        }
        public async Task<bool> CheckAdmin(int id)
        {
            var url = $"{BASE_URL}/admin/{id}";
            var res = await client.GetStringAsync(url);
            return res.Equals("admin");
        }
        public async Task<string?> Create(AccountDto account)
        {
            string url = $"{BASE_URL}/create";
            Account reacc = new() {Name = account.Name, Password = account.Password, Email = account.Email, Image = account.Image, Admin = (bool)account.Admin };
            Console.WriteLine(reacc);
            string json = JsonConvert.SerializeObject(reacc);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url, content);
            if (res.IsSuccessStatusCode) {
                return await res.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
