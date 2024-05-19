using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _dataContext;
        public BlogController(DataContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index()
        {
            var blogs = _dataContext.Blogs.ToList(); // Retrieve blogs from database
            if (!blogs.Any())
            {
                // Optionally handle the scenario where no blogs are found
                return View(new List<DwaysWeb.Models.Blog>());
            }
            return View(blogs); // Pass the list of blogs to the view
        }
    }
}
