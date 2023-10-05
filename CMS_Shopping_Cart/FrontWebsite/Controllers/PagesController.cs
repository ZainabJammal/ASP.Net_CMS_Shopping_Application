using Common.Models;
using Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontWebsite.Controllers
{
    public class PagesController : Controller
    {
        private readonly CmsShoppingCartContext context;
        public PagesController(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        //GET / or / slug
        public async Task<IActionResult> Page(/*string slug*/ int p = 1)
        {
            //if(slug == null)
            //{
            //    return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            //}

            //Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            //if(page == null)
            //{
            //    return NotFound();
            //}

            //return View(page);

            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id)
                                            .Skip((p - 1) * pageSize)
                                            .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);

            return View(await products.ToListAsync());
        }
    }
}
