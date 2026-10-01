using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppTreu2.Controllers
{    
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return Content("Product controller, Index action");
        }

        [Route("Products/{id?}")]
        public IActionResult List(string id = "All")
        {
            return Content("Product controller, List action, Category: " + id);
        }

        public IActionResult List(string id = "All", int num = 1, string sortby = "Price")
        {
            return Content("id=" + id + ", page=" + num + ", sortby=" + sortby);
        }

        [Route("Product/{id}")]
        public IActionResult Detail(int id)
        {
            return Content("Product controller, Detail action, id: " + id);
        }

        [NonAction]
        public string GetSlug(string s) => s.Replace(' ', '-').ToLower();
    }
}
