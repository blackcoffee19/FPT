using Microsoft.AspNetCore.Mvc;

namespace SocialMediaPJ.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
