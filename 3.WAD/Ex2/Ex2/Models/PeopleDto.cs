using System.ComponentModel.DataAnnotations;

namespace Ex2.Models
{
    public class PeopleDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        [DataType("password")]
        public string? Password { get; set; }
        public bool? Role { get; set; }
        public float? Balence { get; set; }
    }
}
