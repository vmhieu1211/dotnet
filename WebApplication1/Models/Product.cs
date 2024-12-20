using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public string? Images { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }


}
