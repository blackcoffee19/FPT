using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.Areas.Admin.Pages.Role
{
    public class DeleteModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [TempData]
        public string? StatusMessage { get; set; }
        public class InputModel
        {
            [Required]
            public string? Id { get; set; }
            public string? Name { get; set; }

        }
        [BindProperty]
        public InputModel? Input { set; get; }
        [BindProperty]
        public bool IsConfirmed { get; set; }
        public void OnGet() => NotFound("Not Found");
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Delete Error");
            }
            var rr = await roleManager.FindByIdAsync(Input.Id);
            if(rr == null)
            {
                return NotFound("Not Found");
            }
            ModelState.Clear();
            if (IsConfirmed)
            {
                await roleManager.DeleteAsync(rr);
                StatusMessage = "Delete Role: " + rr.Name+" successful";
                return RedirectToPage("./Index");
            }
            else
            {
                Input.Name = rr.Name;
                IsConfirmed = true;
            }
            return Page();
        }   
    }
}
