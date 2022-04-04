using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Controllers
{
    public class ProductController : Controller
    {
        private ArtSalesContext context;

        public ProductController(ArtSalesContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "0")
        {
            List<Product> products = context.Products
                    .OrderBy(p => p.Id).ToList();


            var model = products;

            return View(model);
        }

        public IActionResult Details(int id)
        {
            //var categories = context.Categories
            //    .OrderBy(c => c.CategoryID).ToList();

            Product? product = context.Products.Find(id);

            string imageFilename = "";
            if (product != null)
                imageFilename = product.Title + "_m.png";

            //ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            return View(product);
        }
    }
}
