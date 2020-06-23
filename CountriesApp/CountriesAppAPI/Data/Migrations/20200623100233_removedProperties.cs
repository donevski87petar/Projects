using Microsoft.EntityFrameworkCore.Migrations;

namespace CountriesAppAPI.Migrations
{
    public partial class removedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Population",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
