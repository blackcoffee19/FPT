using Day3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class StudentController : Controller
    {
        DemoContext ctx = new DemoContext();
        public IActionResult Index()
        {
            List<Student> students = ctx.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Create(IFormCollection student)
        {
            string name = student["name"];
            string email = student["email"];
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Email: " + email);
            return Redirect("Index");
        }*/
        /* ?? 2*/
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            ctx.Students.Add(stu);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
