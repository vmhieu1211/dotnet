using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public required string  Email { get; set; }
        public required string Password { get; set; }
        public List<Product>? Products { get; set; }

    }
}
