using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DemoIdentity.Areas.Admin.Pages.Role
{
    public class AddModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        [TempData]
        public string? StatusMessage { get; set; }
        public class InputModel
        {
            [Display(Name = "Role Id")]
            public string? Id { get; set; }
            [Required(ErrorMessage ="Please Input the Role name")]
            [Display(Name = "Role Name")]
            [StringLength(100,ErrorMessage ="{0} from {2} to {1} characters",MinimumLength =2)]
            public string? Name { get; set; }    

        }
        [BindProperty]
        public InputModel Input { set; get; }
        [BindProperty]

        public bool IsUpdate { set; get; }
        public AddModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        //Disable default page rout access
        public IActionResult OnGet() => NotFound("Not Found");
        public IActionResult OnPost() => NotFound("Not Found");
        public IActionResult OnPostStartNewRole()
        {
            StatusMessage = "Input Role Information to create new Role";
            IsUpdate = false;
            ModelState.Clear();//xóa model cũ
            return Page();
        }
        public async Task<IActionResult> OnPostAddOrUpdate()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = null;
                return Page();
            }
            if (IsUpdate) {
                if (Input.Id == null)
                {
                    StatusMessage = "Error: Role not found";
                    return Page();
                }
                var rr = await roleManager.FindByIdAsync(Input.Id);
                if (rr != null)
                {
                    rr.Name = Input.Name;
                    var res = await roleManager.UpdateAsync(rr);
                    if (res.Succeeded)
                    {
                        StatusMessage = $"Update Role {Input.Id} successfully";
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        StatusMessage = "Error: ";
                        foreach (var item in res.Errors)
                        {
                            StatusMessage += item.Description;
                        }
                    }
                }
            } else 
            {
                var role = new IdentityRole(Input.Name);
                var res = await roleManager.CreateAsync(role);
                if(res.Succeeded) {
                    StatusMessage = $"Create new Role: {Input.Name} successfully";
                    return RedirectToPage("./Index");
                }
                else
                {
                    StatusMessage = "Error: ";
                    foreach (var item in res.Errors)
                    {
                        StatusMessage += item.Description;
                    }
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostStartUpdate()
        {
            StatusMessage = null;
            IsUpdate = true ;
            if(Input.Id == null)
            {
                StatusMessage = "Error: Role not found";
                return Page();
            }
            var rr = await roleManager.FindByIdAsync(Input.Id);
            if(rr != null)
            {
                Input.Name = rr.Name;
                ModelState.Clear();
            }
            else
            {
                StatusMessage = $"Error: {Input.Id} not found";
            }
            return Page();
        }
        
    }
}
