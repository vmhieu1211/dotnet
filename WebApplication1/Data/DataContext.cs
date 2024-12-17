using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Product>()
                .HasOne(p => p.User)        
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.CreatedBy)  
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
