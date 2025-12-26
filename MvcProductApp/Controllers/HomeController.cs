using Microsoft.AspNetCore.Mvc;
using MvcProductApp.Models;
using MvcProductApp.Services;
using System.Diagnostics;

namespace MvcProductApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var featuredProduct = _productService.GetFeaturedProduct();
            ViewData["FeaturedProduct"] = featuredProduct?.Name ?? "No products yet!";
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

