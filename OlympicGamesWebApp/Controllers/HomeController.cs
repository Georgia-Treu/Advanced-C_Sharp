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
        
        public IActionResult Index(string game = "all", string category = "all")
        {
            var session = new OlympicSession(HttpContext.Session);

            session.SetActiveGame(game);
            session.SetActiveCategory(category);

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
                ActiveGame = game,
                ActiveCategory = category,
                Games = context.Games.OrderBy(g => g.Name).ToList(),
                Categories = context.Categories.OrderBy(c => c.Name).ToList()
            };

            IQueryable<Country> query = context.Countries.Include(c => c.Game).Include(c => c.Category);

            if (game != "all")
                query = query.Where(c => c.GameID == game);

            if (category != "all")
                query = query.Where(c => c.CategoryID == category);

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
