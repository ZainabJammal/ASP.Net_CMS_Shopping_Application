﻿using Common.Models;
using Common.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontWebsite.Controllers
{
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly CmsShoppingCartContext context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(CmsShoppingCartContext context, IWebHostEnvironment _webHostEnvironment)
        {
            this.context = context;
            this._webHostEnvironment = _webHostEnvironment;
        }

        //GET / products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id)
                                            .Skip((p - 1) * pageSize)
                                            .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);

            return View(await products.ToListAsync());
        }

        //GET / products/category
        public async Task<IActionResult> ProductsByCategory(string categorySlug= "", int p = 1)
        {
            Category category = await context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id)
                                            .Where(x => x.CategoryId == category.Id)
                                            .Skip((p - 1) * pageSize)
                                            .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categorySlug;

            return View(await products.ToListAsync());
        }


        public IActionResult Search(string searchquery)
        {
            var results = context.Products.Where(p => p.Name.Contains(searchquery)).ToList();
            return View(results); 
        }

        //public IActionResult Filter(int? categoryId)
        //{
        //    IQueryable<Product> products = context.Products.Include(p => p.Category);

        //    if (categoryId.HasValue)
        //    {
        //        products = products.Where(p => p.CategoryId == categoryId);
        //    }

        //    return View(products.ToList());
        //}
    }
}
