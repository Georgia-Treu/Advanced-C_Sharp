using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OlympicGamesWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "indoor", "Indoor" },
                    { "outdoor", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "para", "Paralympics" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "FlagImage", "GameID", "Name", "Sport" },
                values: new object[,]
                {
                    { "aut", "outdoor", "austria.png", "para", "Austria", "Canoe Sprint" },
                    { "bra", "outdoor", "brazil.png", "summer", "Brazil", "Road Cycling" },
                    { "can", "indoor", "canada.png", "winter", "Canada", "Curling" },
                    { "chn", "indoor", "china.png", "summer", "China", "Diving" },
                    { "cyp", "indoor", "cyprus.png", "youth", "Cyprus", "Breakdancing" },
                    { "fin", "outdoor", "finland.png", "youth", "Finland", "Skateboarding" },
                    { "fra", "indoor", "france.png", "youth", "France", "Breakdancing" },
                    { "gbr", "indoor", "greatbritain.png", "winter", "Great Britain", "Curling" },
                    { "ger", "indoor", "germany.png", "summer", "Germany", "Diving" },
                    { "ita", "outdoor", "italy.png", "winter", "Italy", "Bobsleigh" },
                    { "jam", "outdoor", "jamaica.png", "winter", "Jamaica", "Bobsleigh" },
                    { "jpn", "outdoor", "japan.png", "winter", "Japan", "Bobsleigh" },
                    { "mex", "indoor", "mexico.png", "summer", "Mexico", "Diving" },
                    { "nld", "outdoor", "netherlands.png", "summer", "Netherlands", "Cycling" },
                    { "pak", "outdoor", "pakistan.png", "para", "Pakistan", "Canoe Sprint" },
                    { "prt", "outdoor", "portugal.png", "youth", "Portugal", "Skateboarding" },
                    { "rus", "indoor", "russia.png", "youth", "Russia", "Breakdancing" },
                    { "svk", "outdoor", "slovakia.png", "youth", "Slovakia", "Skateboarding" },
                    { "swe", "indoor", "sweden.png", "winter", "Sweden", "Curling" },
                    { "tha", "indoor", "thailand.png", "para", "Thailand", "Archery" },
                    { "ukr", "indoor", "ukraine.png", "para", "Ukraine", "Archery" },
                    { "uru", "indoor", "uruguay.png", "para", "Uruguay", "Archery" },
                    { "usa", "outdoor", "usa.png", "summer", "USA", "Road Cycling" },
                    { "zwe", "outdoor", "zimbabwe.png", "para", "Zimbabwe", "Canoe Sprint" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
