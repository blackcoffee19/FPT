using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestReactApi.Data;

namespace TestReactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountDbContext ctx;
        public AccountController(AccountDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [Route("login/{email}/{password}")]
        public async Task<ActionResult<Account?>> Login(string email, string password)
        {
            Account? acc = await ctx.Accounts.FirstOrDefaultAsync(x=>x.Email==email && x.Password==password);
            return Ok(acc);
        }
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<Account>?>> ListAccount([FromQuery(Name = "search")] string? search)
        {
            if (search == null)
            {
                return Ok(await ctx.Accounts!.ToListAsync());
            }
            else
            {
                return Ok(await ctx.Accounts!.Where(x=> x.Name!.Contains(search) || x.Email!.Contains(search)).ToListAsync());
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Account?>> FindById(int id)
        {
            return Ok(await ctx.Accounts!.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult<bool>> Update(string id, Account acc)
        {

            try { 
                ctx.Entry(acc).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(true);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            Account? acc = await ctx.Accounts!.FirstOrDefaultAsync(x => x.Id == id);
            if(acc == null) { return BadRequest(); }
            ctx.Entry(acc).State = EntityState.Deleted;
            await ctx.SaveChangesAsync();
            return Ok(true);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<string?>> Create(Account acc)
        {
            try
            {
                await ctx.Accounts!.AddAsync(acc);
                await ctx.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok(acc.Name);
        }
        [HttpGet]
        [Route("admin/{id}")]
        public async Task<ActionResult<string?>> CheckAdmin(int? id)
        {
            if(id== null) { return BadRequest(); }
            Account? acc = await ctx.Accounts!.FirstOrDefaultAsync(x=>x.Id==id);
            if(acc== null) { return BadRequest(); }
            string str = acc.Admin == true ? "admin" : "customer";
            return Ok(str);
        }
    }
}
