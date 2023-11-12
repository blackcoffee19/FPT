using DemoIdentity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoIdentity.Areas.Admin.Pages.Role
{
    public class UserModel : PageModel
    {
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<AppUser> userManager;
        public UserModel(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public class UserAndRole : AppUser
        {
            public string? ListRole { get; set; }
        }
        public List<UserAndRole> Users {  get; set; }
        public IActionResult OnPost() => NotFound("Not Found");
        public async Task<IActionResult> OnGetAsync()
        {
            Users =  await userManager.Users.Select(u=>new UserAndRole { Id = u.Id, UserName = u.UserName }).ToListAsync();
            foreach (var item in Users)
            {
                var roles = await userManager.GetRolesAsync(item);
                item.ListRole = string.Join(", ", roles);
            }
            return Page();

        }
    }
}
