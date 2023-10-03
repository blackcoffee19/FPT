using DemoOrionArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Service.Dtos;

namespace DemoOrionArchitecture.Controllers
{
    public class AccountController : Controller
    {
        IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            AccountDto res = await service.Login(model.Email, model.Password);
            if(res == null)
            {
                return View("Index",model);
            }
            else
            {
                return RedirectToAction("ViewAccount");
            }
        }
        public async Task<IActionResult> ViewAccount()
        {
            var accounts = await service.FindAll();
            return View(accounts);
        }
    }
}
