using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LenselinkArtSales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }
    }
}