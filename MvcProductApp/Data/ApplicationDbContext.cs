using Microsoft.EntityFrameworkCore;
using MvcWebApp_Wk3v2.Features.Product; // This 'using' statement is required

namespace MvcWebApp_Wk3v2.Data
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

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1299.99m },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 79.99m },
                new Product { Id = 3, Name = "Mechanical Keyboard", Price = 149.50m },
                new Product { Id = 4, Name = "4K Monitor", Price = 650.00m }
            );
        }
    }
}

