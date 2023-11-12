using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeClient.Models
{
    public class EmployeeDto
    {
        public string? EmployeeId { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [AllowNull]
        public string? EmployeeName { get; set; }
        [AllowNull]
        public int? Age { get; set; }
        public override string ToString()
        {
            return "EmployeeDto " + this.EmployeeId + "\nName: " + this.EmployeeName + "\nAge: " + this.Age + "\nPassword: " + this.Password;
        }
    }
}
