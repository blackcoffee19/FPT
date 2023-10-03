using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex4.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        [Required]
        public bool? Gender {  get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is invalid")]
        public string? Email { get; set; }
        public override string ToString()
        {
            return "Customer "+this.Name+"\nGender: "+this.Gender+"\nBirthday: "+this.Birthday+"\nEmail: "+this.Email;
        }
    }
}
