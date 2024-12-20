using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public required string  Email { get; set; }
        public required string Password { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();

    }
}
