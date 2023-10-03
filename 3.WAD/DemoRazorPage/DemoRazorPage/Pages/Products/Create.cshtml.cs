using DemoRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages.Products
{
    public class CreateModel : PageModel
    {
        readonly DemoRazorDbContext ctx;
        public CreateModel(DemoRazorDbContext ctx)
        {
            this.ctx = ctx;
        }
        //Tao doi tuong Product => binding du lieu tu form
        [BindProperty]
        public Product Product { get; set; } = default;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || ctx.Products == null ||Product ==null)
            {
                Console.WriteLine("Error");
                Console.WriteLine(Product);
                return Page();
            }
            ctx.Products.Add(Product);
            await ctx.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
