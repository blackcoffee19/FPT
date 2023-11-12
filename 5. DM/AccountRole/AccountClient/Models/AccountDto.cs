using System.ComponentModel.DataAnnotations;

namespace AccountClient.Models
{
    public class AccountDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength (20,ErrorMessage ="Password required max 20 characters")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password not match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        [StringLength(200)]
        public string? Fullname { get; set; }
        [Required]
        [Range(0,1,ErrorMessage ="Role: 0 = customer, 1 = admin")]
        public int? Role { get; set; }
        public override string ToString()
        {
            return "Account DTO: " +this.Email+"\nPassword: "+this.Password+"\nFullName: "+this.Fullname+"\nRole: "+this.Role;
        }
    }
}
