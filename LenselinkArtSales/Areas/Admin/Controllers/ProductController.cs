using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LenselinkArtSales.Models;

namespace LenselinkArtSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ArtSalesContext context;

        public ProductController(ArtSalesContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products = context.Products
                    .OrderBy(p => p.Id).ToList();

            var model = products;
            //{
            //    Products = products,
            //    SelectedCategory = id
            //};

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Product product = new Product();
            //product.Category = context.Categories.Find(1);

            ViewBag.Action = "Add";
            //ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.Id == id);

            ViewBag.Action = "Update";
            //ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                string userMessage = "";
                if (product.Id == 0)
                {
                    context.Products.Add(product);
                    userMessage = "You just added the product " + product.Title;
                }
                else
                {
                    context.Products.Update(product);
                    userMessage = "You just updated the product " + product.Title;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = context.Products
                .FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            product.Active = false;
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
