using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private ArtSalesContext context;
        public SizeController(ArtSalesContext ctx)
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
            List<PrintSize> sizes = context.PrintSizes
                    .OrderBy(p => p.Id).ToList();

            return View(sizes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PrintSize newPrintSize = new PrintSize();
            ViewBag.Action = "Add";
            return View("AddUpdate", newPrintSize);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            PrintSize size = context.PrintSizes.FirstOrDefault(p => p.Id == id);
            ViewBag.Action = "Update";
            return View("AddUpdate", size);
        }

        [HttpPost]
        public IActionResult Update(PrintSize size)
        {
            if (ModelState.IsValid)
            {
                string userMessage = "";
                if (size.Id == 0)
                {
                    context.PrintSizes.Add(size);
                    userMessage = "You just added the new print size " + size.Dimensions;
                }
                else
                {
                    context.PrintSizes.Update(size);
                    userMessage = "You just updated the print size " + size.Dimensions;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", size);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PrintSize size = context.PrintSizes
                .FirstOrDefault(u => u.Id == id);
            return View(size);
        }

        [HttpPost]
        public IActionResult Delete(PrintSize size)
        {
            size = context.PrintSizes
                .FirstOrDefault(u => u.Id == size.Id);
            size.Active = false;
            context.PrintSizes.Update(size);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
