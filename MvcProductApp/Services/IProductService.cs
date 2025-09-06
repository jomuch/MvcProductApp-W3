using MvcProductApp.Features.Product;

namespace MvcProductApp.Services
{
    public interface IProductService
    {
        Product? GetFeaturedProduct();
    }
}