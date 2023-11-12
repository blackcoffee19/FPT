using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoIdentity.Data
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string? Name { get; set; }
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        public int? ParentId {  get; set; }
        [ForeignKey("ParentId")]
        public Category? Parent { get; set; }
        public ICollection<Category>? Children { get; set;}
    }
}
