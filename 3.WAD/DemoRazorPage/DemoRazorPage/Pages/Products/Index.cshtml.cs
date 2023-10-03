using DemoRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.Products
{
    public class IndexModel : PageModel
    {
        readonly DemoRazorDbContext ctx;
        public IList<Product> Products { get; set; }
        public IndexModel(DemoRazorDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task OnGet()
        {
            if(ctx.Products != null)
            {
                Products = await ctx.Products.ToListAsync();
            }
        }
    }
}
