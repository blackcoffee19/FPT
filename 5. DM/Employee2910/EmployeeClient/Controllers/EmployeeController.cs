using EmployeeClient.Models;
using EmployeeClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeClient.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(EmployLogin em)
        {
            EmployeeDto? emp = await service.Login(em);
            if(emp != null)
            {
                return RedirectToAction("EmployeeDetail", new {id = em.EmployeeId});
            }
            else
            {
                return View();
            }
        }
        [Route("EmployeeDetail/{id}")]
        public async Task<IActionResult> EmployeeDetail(string id) {
            EmployeeDto? emp = await service.FindById(id);
            if (emp !=null)
            {
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> ListEmployee() {
            IEnumerable<EmployeeDto>? list = await service.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto em)
        {
            List<EmployeeDto>? list= await service.FindAll();
            int num = list.Count + 1;
            string createId = list.Count() > 9 ? "E" + num : "E0" + num;
            EmployeeDto? check = null;
            do
            {
                check = await service.FindById(createId);
                if (check != null)
                {
                    num++;
                    createId = num > 9 ? "E" + num : "E0" + num;
                }
            } while (check != null);
            em.EmployeeId = createId; 
            if (ModelState.IsValid)
            {
                EmployeeDto? create = await service.Create(em);
                if(create != null)
                {
                    return RedirectToAction("ListEmployee");
                }
            }
            return View(em);
        }
        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(string id) {
            EmployeeDto? emp = await service.FindById(id);
            if (emp != null)
            {
                return View(emp);
            }
            return RedirectToAction("ListEmployee");
        }
        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(string id, EmployeeDto emp)
        {
            if (ModelState.IsValid)
            {
                bool update = await service.Update(id, emp);
                if(update)
                {
                    return RedirectToAction("ListEmployee");
                }
            }
            return View(emp);
        }
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool delete = await service.Delete(id);
            if (!delete)
            {
                Console.WriteLine("Delete false");
            }
            return RedirectToAction("ListEmployee");
        }
    }
}
