using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
