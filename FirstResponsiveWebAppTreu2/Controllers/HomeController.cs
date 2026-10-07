using FirstResponsiveWebAppTreu2.Models;
using Microsoft.AspNetCore.Mvc;


namespace FirstResponsiveWebAppTreu2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome to my C# class Web App";
            return View();
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
