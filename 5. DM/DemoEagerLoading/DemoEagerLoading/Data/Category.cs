using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoEagerLoading.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
