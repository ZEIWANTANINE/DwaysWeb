
using DwaysWeb.Models;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DwaysWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger , DataContext context)
        {
            _logger = logger;
            _datacontext = context;
        }

        public IActionResult Index()
        {
            var products = _datacontext.Products.ToList();
            return View(products);
            
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}