using System.ComponentModel.DataAnnotations;

namespace Ex3.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string? Username { get; set; }
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [MaxLength(50)]
        public string? Image { get; set; }
        public bool Role {  get; set; } = false;
    }
}
