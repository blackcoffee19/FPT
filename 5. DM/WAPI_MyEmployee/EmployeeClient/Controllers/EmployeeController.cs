using EmployeeClient.Models;
using EmployeeClient.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeClient.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(EmployeeDto emp)
        {
            Console.WriteLine(emp.EmployeeId);
            Console.WriteLine(emp.Password);
            EmployeeDto? checkEmp = await service.FindEmployee(emp.EmployeeId);
            Console.WriteLine(checkEmp);
            if (checkEmp != null && checkEmp.Password == emp.Password)
            {
                return RedirectToAction("ListEmployee");
            }
            else
            {
                return View(emp);
            }
        }
        public async Task<IActionResult> ListEmployee()
        {
            IEnumerable<EmployeeDto>? empls = await service.ListAll();
            return View(empls);
        }
        [Route("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(string? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            EmployeeDto? em = await service.FindEmployee(id);
            if (em != null) { return View(em); }
            return RedirectToAction("Index");
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto emp)
        {
            string? create = await service.Create(emp);
            if(create != null)
            {
                return RedirectToAction("ListEmployee");
            }
            else
            {
                return View(emp);
            }
        }
        [HttpPost]
        [Route("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(string id, EmployeeDto emp)
        {
            bool update = await service.Update(id,emp);
            if(update == false) { return View(id); }
            return RedirectToAction("ListEmployee");
        }
    }
}
