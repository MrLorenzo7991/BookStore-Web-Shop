using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_Web_Shop.Migrations
{
    public partial class AggiuntoPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "SellLog",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderLog",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SellLog");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLog");
        }
    }
}
