namespace OlympicGamesWebApp.Models
{
    public class OlympicSession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string CategoryKey = "category";

        private ISession session {  get; set; }

        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public void SetFavoriteCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }

        public List <Country> GetFavoriteCountries()
        {
            return session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        }

        public int? GetFavoriteCount()
        {
            return session.GetInt32(CountKey);
        }

        public void SetActiveGame(string activeGame)
        {
            session.SetString(GameKey, activeGame);
        }

        public string GetActiveGame()
        {
            return session.GetString(GameKey) ?? "";
        }

        public void SetActiveCategory(string activeCategory)
        {
            session.SetString(CategoryKey, activeCategory);
        }

        public string GetActiveCategory()
        {
            return session.GetString(CategoryKey) ?? "";
        }

        public void RemoveFavorites()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }
}
