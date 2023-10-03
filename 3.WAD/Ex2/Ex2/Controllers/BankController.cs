using Ex2.Models;
using Ex2.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Ex2.Controllers
{
    public class BankController : Controller
    {
        PeopleRepository repo;

        public BankController( PeopleRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(PeopleDto peo)
        {
            if(peo.Username!=null && peo.Password!=null)
            {
                PeopleDto? check = await repo.Login(peo.Username, peo.Password);
                if(check != null)
                {
                    //Dang nhap dung
                    if (check.Role.Value)
                    {
                        var session = HttpContext.Session;
                        session.SetString("Username", check.Username);
                        return RedirectToAction("Menu");
                    }
                    else
                    {
                        return View("Customer",check);
                    }
                }
                else
                {
                    return RedirectToAction("Index",repo);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Menu()
        {
            return View("Menu");
        }
        public async Task<IActionResult> ShowAll() {
            IEnumerable<PeopleDto> people = await repo.ShowAll();
            return View(people);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
