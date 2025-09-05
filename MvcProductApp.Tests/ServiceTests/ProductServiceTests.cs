using Microsoft.EntityFrameworkCore;
using MvcWebApp_Wk3v2;
using MvcProductApp.Models;
using MvcProductApp.Services;
using Xunit;
using MvcWebApp_Wk3v2.Features.Product;

namespace MvcProductApp.Tests.ServiceTests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetFeaturedProduct_ReturnsMostExpensiveProduct()
        {
            // Arrange: Set up the in-memory database
            var options = new DbContextOptionsBuilder<MvcWebApp_Wk3v2.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductTestDb")
                .Options;

            // Use a 'using' block to ensure the context is disposed properly
            using (var context = new MvcWebApp_Wk3v2.Data.ApplicationDbContext(options))
            {
                // Seed the database with test data
                context.Products.Add(new Product { Id = 1, Name = "Laptop", Price = 1200.00m });
                context.Products.Add(new Product { Id = 2, Name = "Mouse", Price = 25.50m });
                context.Products.Add(new Product { Id = 3, Name = "Monitor", Price = 350.00m });
                context.SaveChanges();
            }

            // Act: Call the method being tested using a new context instance
            using (var context = new MvcWebApp_Wk3v2.Data.ApplicationDbContext(options))
            {
                var service = new ProductService(context);
                var result = service.GetFeaturedProduct();

                // Assert: Verify the result is correct
                Assert.NotNull(result);
                Assert.Equal("Laptop", result.Name);
                Assert.Equal(1200.00m, result.Price);
            }
        }
    }
}