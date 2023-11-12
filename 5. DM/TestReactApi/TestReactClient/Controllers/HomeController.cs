using Microsoft.AspNetCore.Mvc;

namespace TestReactClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
