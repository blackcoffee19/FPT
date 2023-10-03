using System.ComponentModel.DataAnnotations;

namespace Day4_Codefirst.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }  
        public int Price { get; set; }
    }
}
