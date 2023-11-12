using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAPI_MyEmployee.Models
{
    public class Employee
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string? EmployeeId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string? Password { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string? EmployeeName { get; set; }
        public int? Age { get; set; }
        public override string ToString()
        {
            return "Employee " + this.EmployeeId + "\nName: " + this.EmployeeName + "\nAge: " + this.Age + "\nPassword: " + this.Password;
        }
    }
}
