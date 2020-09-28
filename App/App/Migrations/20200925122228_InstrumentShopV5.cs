using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InstrumentShopV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Goods");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Instruments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Instruments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Manufacturer",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
