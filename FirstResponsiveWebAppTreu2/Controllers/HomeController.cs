using FirstResponsiveWebAppTreu2.Models;
using Microsoft.AspNetCore.Mvc;


namespace FirstResponsiveWebAppTreu2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FirstResponsiveWebAppModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.AgeEndYear = model.AgeThisYear();
                ViewBag.NameEntered = model.Name;

                return View(model);
            }

            return View(model);
        }

        //attribute routing added for About action
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Custom(int id, int num)
        {
            return Content($"HomeController Custom action: id=" + id + " page=" + num);
        }
    }
}
