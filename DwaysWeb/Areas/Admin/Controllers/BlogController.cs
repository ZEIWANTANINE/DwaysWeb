using DwaysWeb.Models;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BlogController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var blogs = _dataContext.Blogs.ToList();
            if (blogs == null)
            {
                return View(new List<Blog>()); // Pass an empty list to avoid null issues in the view
            }
            return View(blogs);
        }
        public IActionResult Create()
        {
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Blog blog)
        {
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name", blog.BlogId);
            if (ModelState.IsValid)
            {

                var proID = await _dataContext.Blogs.FirstOrDefaultAsync(p => p.BlogId == blog.BlogId);
                if (proID != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(blog);
                }

                if (blog.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product");
                    string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await blog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    blog.BlogPhoto = imageName;

                }
                _dataContext.Update(blog);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Cập nhật blog thành công";
                return RedirectToAction("Create", "Blog", new { area = "Admin" });
            }
            else
            {
                TempData["error"] = "Model có một vài thứ bị lỗi";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);

                    }
                }
                string errorMessage = string.Join(", ", errors);
                return BadRequest(errorMessage);
            }
            return View(blog);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            Blog blog = await _dataContext.Blogs.FindAsync(Id);
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name", blog.BlogId);
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Blog blog)
        {
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name", blog.BlogId);
            if (ModelState.IsValid)
            {

                var proID = await _dataContext.Blogs.FirstOrDefaultAsync(p => p.BlogId == blog.BlogId);
                if (proID != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(blog);
                }
                if (blog.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product");
                    string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await blog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    blog.BlogPhoto = imageName;

                }
                _dataContext.Add(blog);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm blog thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Model có một vài thứ bị lỗi";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);

                    }
                }
            }
            return View(blog);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Blog blog = await _dataContext.Blogs.FindAsync(Id);
            if (!string.Equals(blog.BlogPhoto, "noname.jpg"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/products");
                string oldfileImage = Path.Combine(uploadsDir, blog.BlogPhoto);
                if (System.IO.File.Exists(oldfileImage))
                {
                    System.IO.File.Delete(oldfileImage);
                }

            }
            _dataContext.Blogs.Remove(blog);
            await _dataContext.SaveChangesAsync();
            TempData["error"] = "Sản phẩm đã xoá";
            return RedirectToAction("Index");
        }

    }
}
