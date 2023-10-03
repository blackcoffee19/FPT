using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.Data
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [StringLength(100)]
        public string? Name { get; set; }
        [PersonalData]
        [DataType(DataType.DateTime)]
        public DateTime? Birthday { get; set; }
    }
}
