using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
