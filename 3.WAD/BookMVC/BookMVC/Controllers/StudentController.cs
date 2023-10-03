using BookMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DemoEntities ctx= new DemoEntities();
        public ActionResult Index()
        {
            List<Student> students = ctx.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            student.id = ctx.Students.Count();
            ctx.Students.Add(student);
            ctx.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}