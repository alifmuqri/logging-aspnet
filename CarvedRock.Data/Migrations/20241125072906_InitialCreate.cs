using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvedRock.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 1, "boots", "Great support in this high-top to take you to great heights and trails.", "https://www.pluralsight.com/content/dam/pluralsight2/teach/author-tools/carved-rock-fitness/img-brownboots.jpg", "Trailblazer", 69.989999999999995 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 2, "boots", "Easy in and out with this lightweight but rugged shoe with great ventilation to get your around shores, beaches, and boats.", "https://www.pluralsight.com/content/dam/pluralsight2/teach/author-tools/carved-rock-fitness/img-greyboots.jpg", "Coastliner", 49.990000000000002 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 3, "boots", "All the insulation and support you need when wandering the rugged trails of the woods and backcountry.", "/images/shutterstock_222721876.jpg", "Woodsman", 64.989999999999995 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { 4, "boots", "Get up and down rocky terrain like a billy-goat with these awesome high-top boots with outstanding support.", "/images/shutterstock_475046062.jpg", "Billy", 79.989999999999995 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
