using AccountClient.Models;
using AccountClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountClient.Controllers
{
    public class AccountController : Controller
    {
        IAccountService service;
        public AccountController (IAccountService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AccountLogin acc)
        {
            Console.WriteLine(acc);
            AccountDto? account = await service.Login(acc.Email, acc.Password);
            Console.WriteLine(account);
            if (account == null)
            {
                return View();
            }
            else
            {
                if(account.Role == 0)
                {
                    return View("AccountDetail", account);
                }
                else
                {
                    return RedirectToAction("ListAccount");
                }
            }
            
        }
        [HttpGet]
        [Route("detail/{email}")]
        public async Task<IActionResult> AccountDetail(string? email)
        {
            AccountDto acc;
            if (email != null)
            {
               acc = await service.Detail(email);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(acc);
        }
        [HttpGet]
        public async Task<IActionResult> ListAccount()
        {
            IEnumerable<AccountDto>? list = await service.List();
            return View(list) ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountDto acc)
        {
            if (ModelState.IsValid)
            {
                bool create = await service.Create(acc);
                if(create)
                {
                    return RedirectToAction("ListAccount");
                }
                else
                {
                    return View(acc);
                }
            }
            else
            {
                return View(acc);
            }
        }
        [HttpGet]
        [Route("update/{email}")]
        public async Task<IActionResult> Update(string? email) {
            if (email == null) { return RedirectToAction("ListAccount"); }
            AccountDto? acc = await service.Detail(email);
            return View(acc);
        }
        [HttpPost]
        [Route("update/{email}")]
        public async Task<IActionResult> Update(string email,AccountDto acc)
        {
            if (ModelState.IsValid) {  
                bool update = await service.Update(email, acc);
                if (update)
                {
                    return RedirectToAction("ListAccount");
                }
            }
            return View(acc);
        }
        [HttpGet]
        [Route("delete/{email}")]
        public async Task<IActionResult> Delete(string? email)
        {
            if (email != null)
            {
                AccountDto? acc = await service.Detail(email);
                if (acc!=null &&acc.Role == 0)
                {
                    Console.WriteLine(acc);
                    bool ass = await service.Delete(acc);
                }
            }
            return RedirectToAction("ListAccount");
        }
    }
}
