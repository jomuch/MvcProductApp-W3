using Microsoft.EntityFrameworkCore;
using MvcProductApp.Features.Product; // Updated using

namespace MvcProductApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");

            // Your seed data...
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1299.99m },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 79.99m }
                // Add other seed data here
            );
        }
    }
}