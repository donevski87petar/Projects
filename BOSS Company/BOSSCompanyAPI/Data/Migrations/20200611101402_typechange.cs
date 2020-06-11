using Microsoft.EntityFrameworkCore.Migrations;

namespace BOSSCompanyAPI.Migrations
{
    public partial class typechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Socks",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ProductPrice",
                table: "Socks",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
