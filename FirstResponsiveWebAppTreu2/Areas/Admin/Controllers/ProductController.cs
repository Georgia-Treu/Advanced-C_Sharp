using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppTreu2.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Admin")]
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            return Content("Product controller, List action, Category: " + id);
        }

        [Area("Admin")]
        public IActionResult Add()
        {
            return Content("Admin Product Controller, Add Action");
        }

        [Area("Admin")]
        public IActionResult Update(int id)
        {
            return Content("Admin Product controller, Update action, Id: " + id);
        }

        [Area("Admin")]
        public IActionResult Delete(int id)
        {
            return Content("Admin Product controller, Delete action, Id: " + id);
        }

    }
}
