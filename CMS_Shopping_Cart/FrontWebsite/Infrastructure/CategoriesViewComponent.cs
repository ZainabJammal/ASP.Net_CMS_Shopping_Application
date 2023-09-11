using Common.Models;
using Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontWebsite.Infrastructure
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly CmsShoppingCartContext context;
        public CategoriesViewComponent(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<Category>> GetCategoriesAsync()
        {
            return context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
