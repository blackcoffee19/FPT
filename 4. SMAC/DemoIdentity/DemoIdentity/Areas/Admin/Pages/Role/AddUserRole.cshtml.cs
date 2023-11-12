using DemoIdentity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.Areas.Admin.Pages.Role
{
    public class AddUserRoleModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<AppUser> userManager;
        [TempData]
        public string? StatusMessage { get; set; }
        public class InputModel
        {
            [Required]
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string[]? RoleNames { get; set; }
        }
        [BindProperty]
        public InputModel? Input { get; set; }
        [BindProperty]
        public bool IsConfirm { get; set; }
        public AddUserRoleModel(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult OnGet() => NotFound("Page Not found");
        public SelectList? AllRoles {  get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.FindByIdAsync(Input.Id);
            if (user == null)
            {
                return NotFound("Not found User");
            }
            var userRoles = await userManager.GetRolesAsync(user);
            var allRs = await roleManager.Roles.ToListAsync();
            var allRoleName = allRs.Select(x=>x.Name).ToList();
            AllRoles = new SelectList(allRoleName);
            if(!IsConfirm)
            {
                IsConfirm = true;
                Input.RoleNames = userRoles.ToArray();
                StatusMessage = "";
                ModelState.Clear();
            }
            else
            {
                IsConfirm = false;
                StatusMessage = "Update Role for user successful";
                if (Input.RoleNames == null)
                {
                    Input.RoleNames = new string[] { };
                }
                //thêm Roles mới
                foreach (var item in Input.RoleNames)
                {
                    if(!userRoles.Contains(item)) { 
                        await userManager.AddToRoleAsync(user, item);
                    }
                }
                //xóa Roles Cũ , role ko dc chọn trong Input RoleNames
                foreach (var item in userRoles)
                {
                    if (!Input.RoleNames.Contains(item))
                    {
                        await userManager.RemoveFromRoleAsync(user, item);  
                    }
                }

            }
            return Page();
        }
    }
}
