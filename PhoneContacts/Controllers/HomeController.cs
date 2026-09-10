using Microsoft.AspNetCore.Mvc;
using PhoneContacts.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PhoneContacts.Controllers
{
    public class HomeController : Controller
    {
        private PhoneContext context { get; set; }

        public HomeController(PhoneContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var phones = context.Phones.OrderBy(m => m.Name).ToList();
            return View(phones);
        }

       
    }
}
