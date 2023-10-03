using System.ComponentModel.DataAnnotations;

namespace StudentCoreMVC.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
    }
}
