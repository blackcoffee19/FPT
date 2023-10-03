using System.ComponentModel.DataAnnotations;

namespace Ex3.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string? ItemCode { get; set; }
        [MaxLength(50)]
        public string? ItemName { get; set; }
        public int? Price { get; set; }
        [MaxLength(50)]
        public string? Image { get; set; }
        public IFormFile? Photo {  get; set; }
    }
}
