using DwaysWeb.Models;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DwaysWeb.Respository.Components
{
    public class CatergoryViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public CatergoryViewComponent(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var catergories = await _dataContext.Catergories.ToListAsync();
            return View(catergories);
        }

    }
}
