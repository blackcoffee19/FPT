using System.ComponentModel.DataAnnotations;

namespace Ex1.Models
{
    public class NewsDto
    {
        public int NewsId { get; set; }
        [Required]
        public string? HeadLine { get; set; }
        public string? ContentOfNews { get; set; }
    }
}
