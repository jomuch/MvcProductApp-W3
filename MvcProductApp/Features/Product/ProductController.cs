using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebApp_Wk3v2.Data;
using MvcWebApp_Wk3v2.Features.Product;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebApp_Wk3v2.Features.Product
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /products
        [HttpGet("")]
        public async Task<IActionResult> Index(string searchString)
        {
            var products = from p in _context.Products select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }

        // GET: /products/details/5
        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: /products/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /products/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /products/edit/5
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /products/edit/5
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Product product)
        {
            if (id != product.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /products/delete/5
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /products/delete/5
        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

