using Common.Models;
using Common.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    [Authorize(Roles = "admin,editor")]
    //[Area("Admin")]
    public class PagesController : Controller
    {
        private readonly CmsShoppingCartContext context;
        public PagesController(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        //GET /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;
            List<Page> pagesList = await pages.ToListAsync();


            return View(pagesList);
        }

        //GET /admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
                return NotFound();

            return View(page);
        }

        //GET /admin/pages/create
        public IActionResult Create() => View();

        //POST /admin/pages/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid != null)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists");
                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page created successfully!";

                return RedirectToAction("Index");
            }

            return View(page);
        }

        //GET /admin/pages/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
                return NotFound();

            return View(page);
        }

        //POST /admin/pages/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid != null)
            {
                page.Slug = page.Id==1? "home": page.Title.ToLower().Replace(" ", "-");

                var slug = await context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists");
                    return View(page);
                }

                context.Update(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page edited successfully!";

                return RedirectToAction("Edit", new{ id = page.Id});
            }

            return View(page);
        }

        //GET /admin/pages/delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
                TempData["Error"] = "The page doesn't exist!";
            else
            {
                context.Pages.Remove(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page deleted successfully!";
            }

            return RedirectToAction("Index");
        }

        //POST /admin/pages/reorder
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach(var pageId in id)
            {
                Page page = await context.Pages.FindAsync(pageId);
                page.Sorting = count;
                context.Update(page);
                await context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}
