using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;

namespace TestClient.Models
{
    public class AccountDto
    {
        [AllowNull]
        public int? Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Password not match")]
        public string? ConfirmPassword {  get; set; }
        public string? Image { get; set; }
        public bool? Admin { get; set; }
        public IFormFile? Photo { get; set; } = null;
        public override string ToString()
        {
            return "Account: "+this.Id+"\nName: " + this.Name + "\nEmail: " + this.Email + "\nPassword: " + this.Password + " | " + this.ConfirmPassword +"\nAdmin: "+this.Admin+ "\nImage: " + this.Image + "\nPhoto: " + this.Photo; 
        }
    }
}
