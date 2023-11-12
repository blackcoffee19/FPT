using Microsoft.AspNetCore.Mvc;
using WcfClient.Models;
using WcfClient.Service;

namespace WcfClient.Controllers
{
    public class AccountController : Controller
    {
        public IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password) { 
            AccountDto? accountDto = await service.Login(username, password);
            if (accountDto == null) { return View(); }
            return RedirectToAction("ListAccount");
        }
        public async Task<IActionResult> ListAccount()
        {
            IEnumerable<AccountDto>? accs = await service.FindAll(); 
            return View(accs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountDto accountDto)
        {
            if (accountDto == null)
            {
                return View();
            }
            else
            {
                int? acc = await service.Create(accountDto);
                if (acc == null) { return View(); }
                return RedirectToAction("ListAccount");
            }
        }
    }
}
