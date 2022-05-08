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
            var model = new List<ProductImageListView>();
            List<Product> products = context.Products
                    .OrderBy(p => p.Id).ToList();

            foreach(var product in products)
            {
                List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();

                model.Add(new ProductImageListView { product = product, productImages = productImages });
            }
            //var model = products;
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
            var model = new ProductImageListView();

            ViewBag.Action = "Add";
            //ViewBag.Categories = categories;

            return View("AddUpdate", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductImageListView item = new ProductImageListView();
            Product product = context.Products.FirstOrDefault(p => p.Id == id);
            List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();

            item.product = product;
            item.productImages = productImages;
            ViewBag.Action = "Update";

            return View("AddUpdate", item);
        }

        [Route("[area]/[controller]/Update/{id}/AddImage")]
        public IActionResult AddImage(int id)
        {
            ProductImageListView item = new ProductImageListView();
            Product product = context.Products.FirstOrDefault(p => p.Id == id);
            List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();
            productImages.Add(new ProductImage());

            item.product = product;
            item.productImages = productImages;
            ViewBag.Action = "Update";

            return View("AddUpdate", item);
        }

        [Route("[area]/[controller]/Update/{id}/RemoveImage/{imageId}")]
        public IActionResult RemoveImage(int id, int imageId)
        {
            ProductImageListView item = new ProductImageListView();
            Product product = context.Products.FirstOrDefault(p => p.Id == id);
            List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();

            if (imageId == 0)
            {
                productImages.Add(new ProductImage());
            }
            {
                productImages.Remove(productImages.Where(p => p.Id == id).First());
            }

            item.product = product;
            item.productImages = productImages;
            ViewBag.Action = "Update";

            return View("AddUpdate", item);
        }

        [HttpPost]
        public IActionResult Update(ProductImageListView item)
        {
            if (ModelState.IsValid)
            {
                string userMessage = "";
                if (item.product.Id == 0)
                {
                    context.Products.Add(item.product);
                    userMessage = "You just added the product " + item.product.Title;
                }
                else
                {
                    context.Products.Update(item.product);
                    userMessage = "You just updated the product " + item.product.Title;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", item);
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
