using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        public ProductController (DataContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int ProductId)
        {
            try
            {
                var productById = await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);

                if (productById == null)
                {
                    return NotFound(); // Handle case where product not found
                }

                // Log or debug the retrieved product:
                Console.WriteLine($"Retrieved product: {productById.ProductName}");

                return View(productById);
            }
            catch (Exception ex)
            {
                // Log or handle any exceptions
                Console.WriteLine($"Error retrieving product: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
