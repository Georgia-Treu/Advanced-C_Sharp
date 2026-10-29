namespace OlympicGamesWebApp.Models
{
    public class OlympicCookies
    {
        private const string CountriesKey = "mycountries";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; } = null!;
        private IResponseCookies responseCookies { get; set; } = null!;

        public OlympicCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }

        public OlympicCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyCountryIds(List<Country> countries)
        {
            List<string> ids = countries.Select(c => c.CountryID).ToList();
            string idsString = String.Join(Delimiter, ids);

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            RemoveMyCountryIds();

            responseCookies.Append(CountriesKey, idsString, options);
        }

        public string[] GetMyCountryIds()
        {
            string cookie = requestCookies[CountriesKey] ?? String.Empty;

            if (string.IsNullOrEmpty(cookie)) return Array.Empty<string>();

            return cookie.Split(Delimiter);
        }

        public void RemoveMyCountryIds()
        {
            responseCookies.Delete(CountriesKey);
        }
    }
}
