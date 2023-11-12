using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestReactClient.Models;

namespace TestReactClient.Services
{
    public class AccountService : IAccountService
    {
        public HttpClient client;
        public const string BASE_URL = "http://localhost:5274/api/Account";
        public AccountService (HttpClient client)
        {
            this.client = client;
        }
        public async Task<Account?> CheckLogin(string email,string password)
        {
            string url = $"{BASE_URL}/login/{email}/{password}";

            var res = await client.GetStringAsync(url);
            if (res == null)
            {
                return null; 
            }
            return JsonConvert.DeserializeObject<Account>(res);
        }
        public async Task<List<Account>?> ListAccount(string? search)
        {
            var url = search !=null? $"{BASE_URL}/list?search={search}": $"{BASE_URL}/list";    
            var res = await client.GetAsync(url);
            if(res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Account>>(res.ToString());
            }
            else { return null;}
        }
        public async Task<Account?> FindById(int id)
        {
            var url = $"{BASE_URL}/{id}";
            var res = await client.GetStringAsync(url);
            if(res == null) { return null; }
            return JsonConvert.DeserializeObject<Account>(res);
        }
        public async Task<bool> Update(Account account)
        {
            var url = $"{BASE_URL}/update/{account.Id}";
            //Chuyển Account thành chuỗi json 
            string json = JsonConvert.SerializeObject(account);
            //tạo đối tượng HttpClient chưá chuỗi json
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url, content);
            if (res.IsSuccessStatusCode)
            {
                var resp = await res.Content.ReadAsStringAsync();
                if(resp == "true")
                {
                    return true;
                }
                else { return false; }
            }
            else{ return false; }
        }
        public async Task<bool> Delete(int id)
        {
            var url = $"{BASE_URL}/{id}";
            var res = await client.DeleteAsync(url);
            if (res == null) { return false; };
            bool check = await res.Content.ReadAsStringAsync() == "true";
            return check;
        }
    }
}
