
using System.Diagnostics.CodeAnalysis;

namespace TestClient.Models
{
    public class Account
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public bool Admin { get; set; }
    }
}
