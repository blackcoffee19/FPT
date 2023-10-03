using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex2.Data
{
    [Table("tbPeople")]
    public class People
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string? Username { get; set; }
        [MaxLength(30)]
        public string? Password { get; set; }
        public bool? Role {  get; set; }
        public float? Balence {  get; set; } 
    }
}
