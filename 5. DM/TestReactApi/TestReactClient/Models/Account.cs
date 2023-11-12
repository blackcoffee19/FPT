using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestReactClient.Models
{
    public class Account
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
        public string? Image { get; set; }
        public bool? Admin { get; set; }
        public IFormFile? Photo { get; set; } = null;
    }
}
