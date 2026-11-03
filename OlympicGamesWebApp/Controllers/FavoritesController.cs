using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGamesWebApp.Models;

namespace OlympicGamesWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private CountryContext context;
        public FavoritesController(CountryContext ctx) 
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory(),
                Countries = session.GetFavoriteCountries()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountriesViewModel model)
        {
            model.Country = context.Countries.Include(c => c.Game).Include(c => c.Category).Where(c => c.CountryID == model.Country.CountryID).FirstOrDefault() ?? new Country();

            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);
            var countries = session.GetFavoriteCountries();

            countries.Add(model.Country);

            session.SetFavoriteCountries(countries);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.Name} added to favorites";

            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            session.RemoveFavorites();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorites cleared";

            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            });
        }
    }
}
