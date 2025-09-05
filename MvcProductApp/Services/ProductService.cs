using MvcWebApp_Wk3v2;
using MvcWebApp_Wk3v2.Features.Product;

namespace MvcProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly MvcWebApp_Wk3v2.Data.ApplicationDbContext _context;

        public ProductService(MvcWebApp_Wk3v2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Product? GetFeaturedProduct()
        {
            // Business logic: The "featured" product is the most expensive one.
            return _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();
        }
    }
}
