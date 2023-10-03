using Microsoft.AspNetCore.Mvc;

namespace StudentCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
