using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ex1.Data
{
    [Table("tbNews")]
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [MaxLength(20)]
        public string? HeadLine { get; set; }
        [MaxLength(50)]
        public string? ContentOfNews{ get; set; }
    }
}
