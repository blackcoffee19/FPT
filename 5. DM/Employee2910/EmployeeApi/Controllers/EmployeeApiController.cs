using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        EmployeeDbContext ctx;
        public EmployeeApiController(EmployeeDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>?>> FindAll()
        {
            List<Employee>? list = await ctx.Employees!.ToListAsync();  
            return Ok(list);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Employee?>> Create(Employee em)
        {
            try {
                ctx.Employees!.Add(em);
                await ctx.SaveChangesAsync();
            }catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
            return Ok(em);
        }
        [HttpGet]
        [Route("detail/{id}")]
        public async Task<ActionResult<Employee?>> FindById(string id)
        {
            Employee? em = await ctx.Employees!.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return Ok(em);
        }
        [HttpGet]
        [Route("search/{name}")]
        public async Task<ActionResult<List<Employee>?>> Search(string name)
        {
            List<Employee>? list = await ctx.Employees!.Where(o => o.EmployeeName!.Contains(name)).ToListAsync();
            return Ok(list);
        }
        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult<bool>> Update(string id,Employee em)
        {
            try
            {
                ctx.Entry(em).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(true);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            try {
                Employee? em = await ctx.Employees!.FirstOrDefaultAsync(ex=>ex.EmployeeId == id);
                if(em != null)
                {
                    ctx.Entry(em).State = EntityState.Deleted;
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    return Ok(false);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(true);
        }
        [HttpPost]
        [Route("login/{empid}/{password}")]
        public async Task<ActionResult<Employee?>> Login(string empid, string password)
        {
            Employee? emp = await ctx.Employees!.FirstOrDefaultAsync(o => o.EmployeeId == empid && o.Password == password);
            return Ok(emp);
        }
    }
}
