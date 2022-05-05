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
            var model = new List<ProductImageListView>();
            List<Product> products = context.Products
                    .OrderBy(p => p.Id).ToList();

            foreach (var product in products)
            {
                List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();

                model.Add(new ProductImageListView { product = product, productImages = productImages });
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            //var categories = context.Categories
            //    .OrderBy(c => c.CategoryID).ToList();
            var model = new ProductImageListView();
            Product? product = context.Products.Find(id);
            List<ProductImage> productImages = context.ProductImages.Where(r => product.Id.Equals(r.ProductId)).ToList();
            model.product = product;
            model.productImages = productImages;
            string imageFilename = "";
            if (product != null)
                imageFilename = product.Title + "_m.png";

            //ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            return View(model);
        }
    }
}
