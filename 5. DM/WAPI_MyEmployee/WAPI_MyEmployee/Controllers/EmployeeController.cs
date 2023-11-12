using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAPI_MyEmployee.Models;

namespace WAPI_MyEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDBContext ctx;
        public EmployeeController(EmployeeDBContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<Employee>?>> FindAll()
        {
            List<Employee>? employees = await ctx.Employees!.ToListAsync();

            return Ok(employees);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee?>> FindById(string id) {
            Employee? emp = await ctx.Employees!.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if(emp == null) { return NotFound(); }
            return Ok(emp);            
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Update(string id ,Employee emp)
        {
            try
            {
                ctx.Entry(emp).State= EntityState.Modified; 
                await ctx.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(true);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<string>> Create(Employee emp)
        {
            int num = await ctx.Employees!.CountAsync();
            num++;
            if (emp.EmployeeId == null) {
                emp.EmployeeId = "E" + (num < 10 ? "0" + num:num); ; 
            }
            Console.WriteLine(emp);
            try {
                var emp2= await ctx.Employees!.AddAsync(emp);
                await ctx.SaveChangesAsync();
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(emp.EmployeeId);
        } 
    }
}
