using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingController : Controller
    {
        private ArtSalesContext context;
        public ShippingController(ArtSalesContext ctx)
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
            List<ShippingCompany> companies = context.ShippingCompanies
                    .OrderBy(p => p.Id).ToList();

            return View(companies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ShippingCompany newCompany = new ShippingCompany();
            ViewBag.Action = "Add";
            return View("AddUpdate", newCompany);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ShippingCompany company = context.ShippingCompanies.FirstOrDefault(p => p.Id == id);
            ViewBag.Action = "Update";
            return View("AddUpdate", company);
        }

        [HttpPost]
        public IActionResult Update(ShippingCompany company)
        {
            if (ModelState.IsValid)
            {
                string userMessage = "";
                if (company.Id == 0)
                {
                    context.ShippingCompanies.Add(company);
                    userMessage = "You just added the company " + company.CompanyName;
                }
                else
                {
                    context.ShippingCompanies.Update(company);
                    userMessage = "You just updated the company " + company.CompanyName;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", company);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ShippingCompany company = context.ShippingCompanies
                .FirstOrDefault(u => u.Id == id);
            return View(company);
        }

        [HttpPost]
        public IActionResult Delete(ShippingCompany company)
        {
            company = context.ShippingCompanies
                .FirstOrDefault(u => u.Id == company.Id);
            company.Active = false;
            context.ShippingCompanies.Update(company);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
