using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_Web_Shop.Migrations
{
    public partial class aggiuntaColonneOrderSellLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "SellLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "OrderLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "SellLog");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "OrderLog");
        }
    }
}
