using DemoEagerLoading.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEagerLoading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EagerLoadingController : ControllerBase
    {
        EagerLoadingDbContext ctx;
        public EagerLoadingController (EagerLoadingDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<ActionResult> GetProducts()
        {
            var res = await ctx.Products!.Include(o=>o.Category).ToListAsync();
            return Ok(res);
        }
        [Route("category")]
        public async Task<ActionResult> GetCategories()
        {
            var res = await ctx.Categories!.Include(o => o.Products).ToListAsync();
            return Ok(res);
        }
    }
}
