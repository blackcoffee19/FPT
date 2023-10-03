using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex1.Data
{
    [Table(name:"thAdmins")]
    public class Admin
    {
        [Key]
        public string? Username {  get; set; }
        public string? Password { get; set; }
    }
}
