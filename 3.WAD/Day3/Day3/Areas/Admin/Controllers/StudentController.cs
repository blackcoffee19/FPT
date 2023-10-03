using Microsoft.AspNetCore.Mvc;

namespace Day3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
