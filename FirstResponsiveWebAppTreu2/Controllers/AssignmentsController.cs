using Microsoft.AspNetCore.Mvc;
using FirstResponsiveWebAppTreu2.Models;
using System.Collections.Generic;

namespace FirstResponsiveWebAppTreu2.Controllers
{
    public class AssignmentsController : Controller
    {
        [Route("Assignments/Assignment61/{accessLevel:int}")]
        public IActionResult Assignments61(int accessLevel)
        {
            if (accessLevel < 1 || accessLevel > 10)
            {
                return Content("Access level must be between 1 and 10.");
            }

            var students = new List<Student>
            {
                new Student { FirstName = "Olivia", LastName = "Johnson", Grade = "A" },
                new Student { FirstName = "Joseph", LastName = "Rhymes", Grade = "C+" },
                new Student { FirstName = "Rebecca", LastName = "Adams", Grade = "B" }
            };

            var vm = new StudentViewModel
            {
                AccessLevel = accessLevel,
                Students = students
            };

            return View(vm);
        }

        public IActionResult AgeCalculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgeCalculator(FirstResponsiveWebAppTreu2.Models.FirstResponsiveWebAppModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.NameEntered = model.Name;
            ViewBag.AgeEndYear = model.AgeThisYear();

            return View(model);
        }
    }
}
