using MvcProductApp.Data;
using MvcProductApp.Features.Product;
using System.Linq;

namespace MvcProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product? GetFeaturedProduct()
        {
            return _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();
        }
    }
}