using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeClient.Models
{
    public class EmployeeDto
    {
        [AllowNull]
        public string? EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string? EmployeeName { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public int? Age { get; set; }
    }
}
