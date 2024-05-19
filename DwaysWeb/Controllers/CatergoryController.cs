using DwaysWeb.Models;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Controllers
{
    public class CatergoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CatergoryController(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IActionResult> Index(int CatergoryId)
        {
           
            // Tìm kiếm danh mục dựa trên Slug
            Catergory catergory = await _dataContext.Catergories.FirstOrDefaultAsync(c => c.CatergoryId == CatergoryId);

            if (catergory == null)
            {
                // Nếu không tìm thấy danh mục, chuyển hướng đến trang chính
                return RedirectToAction("Index", "Home");
            }

            // Lấy danh sách sản phẩm dựa trên CatergoryId của danh mục
            var productsInCategory = await _dataContext.Products
                .Where(p => p.CatergoryId == catergory.CatergoryId)
                .OrderByDescending(p => p.ProductId)
                .ToListAsync();

            return View(productsInCategory);
        }
    }
}
