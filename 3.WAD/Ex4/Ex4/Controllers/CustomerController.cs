using Ex4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Ex4.Controllers
{
    public class CustomerController : Controller
    {
        CustomersDbContext _db;
        public CustomerController(CustomersDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Customer> cust = await _db.Customers.ToListAsync();
            return View(cust);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer cus)
        {
            if(ModelState.IsValid)
            {
                try {
                    Console.WriteLine(cus);
                    _db.Customers.Add(cus);
                    await _db.SaveChangesAsync();
                }catch(Exception err) { Console.WriteLine(err); }
                return RedirectToAction("Index");
            }
            else
            {
                return View(cus);
            }
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                Customer? cus = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if(cus!= null)
                {
                    _db.Entry(cus).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Search([FromQuery(Name = "s")] string s)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(s);
                IEnumerable<Customer>? cus = await _db.Customers.Where(x => x.Name.Contains(s)).ToListAsync();
                return View("Index",cus);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet("UpdateOrDelete/{id}")]
        public async Task<IActionResult> UpdateOrDelete(int id) {
            Customer? cus = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (cus != null)
            {
                return View(cus);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost("UpdateOrDelete/{id}")]
        public async Task<IActionResult> UpdateOrDelete(int id,Customer cus)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Entry(cus).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }   
}
