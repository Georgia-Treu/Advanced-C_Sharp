using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGamesWebApp.Models;
using System.Diagnostics;

namespace OlympicGamesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }
        
        public IActionResult Index([FromRoute] CountriesViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);

            session.SetActiveGame(model.ActiveGame);
            session.SetActiveCategory(model.ActiveCategory);

            int? count = session.GetFavoriteCount();

            if (!count.HasValue)
            {
                var cookies = new OlympicCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                if (ids.Length > 0)
                {
                    var countries = context.Countries.Include(c => c.Game).Include(c => c.Category).Where(c => ids.Contains(c.CountryID)).ToList();
                    session.SetFavoriteCountries(countries);
                }
            }
            
            var vm = new CountriesViewModel
            {
                ActiveGame = model.ActiveGame,
                ActiveCategory = model.ActiveCategory,
                Games = context.Games.OrderBy(g => g.Name).ToList(),
                Categories = context.Categories.OrderBy(c => c.Name).ToList()
            };

            IQueryable<Country> query = context.Countries.Include(c => c.Game).Include(c => c.Category);

            if (model.ActiveGame != "all")
                query = query.Where(c => c.GameID == model.ActiveGame);

            if (model.ActiveCategory != "all")
                query = query.Where(c => c.CategoryID == model.ActiveCategory);

            vm.Countries = query.OrderBy(c => c.Name).ToList();
          
            
            return View(vm);
        }

        public IActionResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);

            var model = new CountriesViewModel
            {
                Country = context.Countries.Include(c => c.Game).Include(c => c.Category).FirstOrDefault(c => c.CountryID == id) ?? new Country(),

                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
