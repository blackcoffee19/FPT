using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestAdminCRUD.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,}$",ErrorMessage ="Password require letter and number, minLength = 6")]
        public string Password { get; set; }
        [AllowNull]
        public string? Image { get; set; }
        public string? Role { get; set; }
        [AllowNull]
        public IFormFile? Photo { get; set; }
        public override string ToString()
        {
            return "Customer: \nName"+this.Name+"\nEmail: "+this.Email+"\nPassword: "+this.Password+"\nImage: "+this.Image+"\nRole: "+this.Role+"\nPhoto: "+this.Photo;
        }
    }
}
