using Microsoft.EntityFrameworkCore;

namespace OlympicGamesWebApp.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "summer", Name = "Summer Olympics" },
                new Game { GameID = "winter", Name = "Winter Olympics" },
                new Game { GameID = "para", Name = "Paralympics" },
                new Game { GameID = "youth", Name = "Youth Olympic Games" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "indoor", Name = "Indoor"},
                new Category { CategoryID = "outdoor", Name = "Outdoor" }
            );

            modelBuilder.Entity<Country>().HasData(
                new
                {
                    CountryID = "can",
                    Name = "Canada",
                    GameID = "winter",
                    CategoryID = "indoor",
                    Sport = "Curling",
                    FlagImage = "canada.png"
                },
                new
                {
                    CountryID = "swe",
                    Name = "Sweden",
                    GameID = "winter",
                    CategoryID = "indoor",
                    Sport = "Curling",
                    FlagImage = "sweden.png"
                },
                new
                {
                    CountryID = "gbr",
                    Name = "Great Britain",
                    GameID = "winter",
                    CategoryID = "indoor",
                    Sport = "Curling",
                    FlagImage = "greatbritain.png"
                },
                new
                {
                    CountryID = "jam",
                    Name = "Jamaica",
                    GameID = "winter",
                    CategoryID = "outdoor",
                    Sport = "Bobsleigh",
                    FlagImage = "jamaica.png"
                },
                new
                {
                    CountryID = "ita",
                    Name = "Italy",
                    GameID = "winter",
                    CategoryID = "outdoor",
                    Sport = "Bobsleigh",
                    FlagImage = "italy.png"
                },
                new
                {
                    CountryID = "jpn",
                    Name = "Japan",
                    GameID = "winter",
                    CategoryID = "outdoor",
                    Sport = "Bobsleigh",
                    FlagImage = "japan.png"
                },
                new
                {
                    CountryID = "ger",
                    Name = "Germany",
                    GameID = "summer",
                    CategoryID = "indoor",
                    Sport = "Diving",
                    FlagImage = "germany.png"
                },
                new
                {
                    CountryID = "chn",
                    Name = "China",
                    GameID = "summer",
                    CategoryID = "indoor",
                    Sport = "Diving",
                    FlagImage = "china.png"
                },
                new
                {
                    CountryID = "mex",
                    Name = "Mexico",
                    GameID = "summer",
                    CategoryID = "indoor",
                    Sport = "Diving",
                    FlagImage = "mexico.png"
                },
                new
                {
                    CountryID = "bra",
                    Name = "Brazil",
                    GameID = "summer",
                    CategoryID = "outdoor",
                    Sport = "Road Cycling",
                    FlagImage = "brazil.png"
                },
                new
                {
                    CountryID = "nld",
                    Name = "Netherlands",
                    GameID = "summer",
                    CategoryID = "outdoor",
                    Sport = "Cycling",
                    FlagImage = "netherlands.png"
                },
                new
                {
                    CountryID = "usa",
                    Name = "USA",
                    GameID = "summer",
                    CategoryID = "outdoor",
                    Sport = "Road Cycling",
                    FlagImage = "usa.png"
                },
                new
                {
                    CountryID = "tha",
                    Name = "Thailand",
                    GameID = "para",
                    CategoryID = "indoor",
                    Sport = "Archery",
                    FlagImage = "thailand.png"
                },
                new
                {
                    CountryID = "uru",
                    Name = "Uruguay",
                    GameID = "para",
                    CategoryID = "indoor",
                    Sport = "Archery",
                    FlagImage = "uruguay.png"
                },
                new
                {
                    CountryID = "ukr",
                    Name = "Ukraine",
                    GameID = "para",
                    CategoryID = "indoor",
                    Sport = "Archery",
                    FlagImage = "ukraine.png"
                },
                new
                {
                    CountryID = "aut",
                    Name = "Austria",
                    GameID = "para",
                    CategoryID = "outdoor",
                    Sport = "Canoe Sprint",
                    FlagImage = "austria.png"
                },
                new
                {
                    CountryID = "pak",
                    Name = "Pakistan",
                    GameID = "para",
                    CategoryID = "outdoor",
                    Sport = "Canoe Sprint",
                    FlagImage = "pakistan.png"
                },
                new
                {
                    CountryID = "zwe",
                    Name = "Zimbabwe",
                    GameID = "para",
                    CategoryID = "outdoor",
                    Sport = "Canoe Sprint",
                    FlagImage = "zimbabwe.png"
                },
                new
                {
                    CountryID = "fra",
                    Name = "France",
                    GameID = "youth",
                    CategoryID = "indoor",
                    Sport = "Breakdancing",
                    FlagImage = "france.png"
                },
                new
                {
                    CountryID = "cyp",
                    Name = "Cyprus",
                    GameID = "youth",
                    CategoryID = "indoor",
                    Sport = "Breakdancing",
                    FlagImage = "cyprus.png"
                },
                new
                {
                    CountryID = "rus",
                    Name = "Russia",
                    GameID = "youth",
                    CategoryID = "indoor",
                    Sport = "Breakdancing",
                    FlagImage = "russia.png"
                },
                new
                {
                    CountryID = "fin",
                    Name = "Finland",
                    GameID = "youth",
                    CategoryID = "outdoor",
                    Sport = "Skateboarding",
                    FlagImage = "finland.png"
                },
                new
                {
                    CountryID = "svk",
                    Name = "Slovakia",
                    GameID = "youth",
                    CategoryID = "outdoor",
                    Sport = "Skateboarding",
                    FlagImage = "slovakia.png"
                },
                new
                {
                    CountryID = "prt",
                    Name = "Portugal",
                    GameID = "youth",
                    CategoryID = "outdoor",
                    Sport = "Skateboarding",
                    FlagImage = "portugal.png"
                }
            );
        }
    }
}
