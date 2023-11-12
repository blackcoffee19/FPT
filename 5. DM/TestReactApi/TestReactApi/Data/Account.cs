using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestReactApi.Data
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string? Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string? Password { get; set; }
        [AllowNull]
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string? Image {  get; set; }
        public bool Admin {  get; set; }
    }
}
