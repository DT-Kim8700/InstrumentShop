using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InstrumentShopV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoodsName",
                table: "Goods",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "Goods",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsName",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "Goods");
        }
    }
}
