using DwaysWeb.Models;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var products = _dataContext.Products.ToList();
            if (products == null)
            {
                return View(new List<Products>()); // Pass an empty list to avoid null issues in the view
            }
            return View();
        }
        public IActionResult Create() {
            ViewBag.Catergories= new SelectList(_dataContext.Catergories,"Id","Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
        {
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name", product.CatergoryId);
            if (ModelState.IsValid)
            {
                
                var proID= await _dataContext.Products.FirstOrDefaultAsync(p=>p.ProductId == product.ProductId);    
                if (proID != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(product);
                }
                if(product.ImageUpload!=null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath= Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);  
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.ProductPhoto = imageName;

                }
                _dataContext.Update(product);
                await _dataContext.SaveChangesAsync();  
                TempData["success"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Model có một vài thứ bị lỗi";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors) {
                        errors.Add(error.ErrorMessage);
                    
                    }
                }
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            Products product = await _dataContext.Products.FindAsync(Id);
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name",product.CatergoryId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id,Products product)
        {
            ViewBag.Catergories = new SelectList(_dataContext.Catergories, "Id", "Name", product.CatergoryId);
            if (ModelState.IsValid)
            {
                
                var proID = await _dataContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
                if (proID != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(product);
                }
                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.ProductPhoto = imageName;

                }
                _dataContext.Add(product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm sản phẩm thành công";
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
            return View(product);
        }
        public async Task<IActionResult> Delete (int Id)
        {
            Products product = await _dataContext.Products.FindAsync(Id);
            if(!string.Equals(product.ProductPhoto, "noname.jpg")) {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/products");
                string oldfileImage = Path.Combine(uploadsDir, product.ProductPhoto);
                if(System.IO.File.Exists(oldfileImage))
                {
                    System.IO.File.Delete(oldfileImage);
                }
            
            }
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            TempData["error"] = "Sản phẩm đã xoá";
            return RedirectToAction("Index");
        }
    }
}
