using MvcWebApp_Wk3v2.Features.Product;

namespace MvcProductApp.Services
{
    public interface IProductService
    {
        Product? GetFeaturedProduct();
    }
}