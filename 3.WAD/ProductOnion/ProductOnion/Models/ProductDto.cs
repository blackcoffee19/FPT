using System.ComponentModel.DataAnnotations;

namespace ProductOnion.Models
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(0,int.MaxValue)]
        public int Price { get; set; }
        public string? Image { get; set; }
        public IFormFile? Photo {  get; set; }
    }
}
