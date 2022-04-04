using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private ArtSalesContext context;

        public UserController(ArtSalesContext ctx)
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
            List<User> users = context.Users
                    .OrderBy(p => p.Id).ToList();

            ViewBag.Roles = context.SecurityRoles
                    .OrderBy(p => p.Id).ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            User user = new User();
            ViewBag.Roles = context.SecurityRoles
                    .OrderBy(p => p.Id).ToList();

            ViewBag.questions = context.SecurityQuestions
                    .OrderBy(p => p.Id).ToList();

            ViewBag.Action = "Add";
            //ViewBag.Categories = categories;

            return View("AddUpdate", user);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = context.Users.FirstOrDefault(p => p.Id == id);

            ViewBag.Roles = context.SecurityRoles
                    .OrderBy(p => p.Id).ToList();

            ViewBag.questions = context.SecurityQuestions
                    .OrderBy(p => p.Id).ToList();

            ViewBag.Action = "Update";
            //ViewBag.Categories = categories;

            return View("AddUpdate", user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                string userMessage = "";
                if (user.Id == 0)
                {
                    context.Users.Add(user);
                    userMessage = "You just added the user " + user.FirstLastname;
                }
                else
                {
                    context.Users.Update(user);
                    userMessage = "You just updated the user " + user.FirstLastname;
                }
                context.SaveChanges();
                TempData["UserMessage"] = userMessage;

                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", user);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            User user = context.Users
                .FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            user = context.Users
                .FirstOrDefault(u => u.Id == user.Id);
            user.Active = false;
            context.Users.Update(user);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
