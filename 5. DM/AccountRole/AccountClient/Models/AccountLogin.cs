using System.ComponentModel.DataAnnotations;

namespace AccountClient.Models
{
    public class AccountLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password invalid")]
        public string? Password { get; set; }
        public override string ToString()
        {
            return "Account Login: " + this.Email + "\nPassword: " + this.Password ;
        }
    }
}
