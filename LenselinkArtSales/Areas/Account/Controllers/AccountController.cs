using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
