using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; }
            public string? Images { get; set; }
            public int CreatedBy { get; set; } 
            public DateTime CreatedAt { get; set; }

            public User User { get; set; } = null!; 
        }

    
}
