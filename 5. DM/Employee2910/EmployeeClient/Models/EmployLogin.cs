using System.ComponentModel.DataAnnotations;

namespace EmployeeClient.Models
{
    public class EmployLogin
    {
        [Required]
        public string? EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
