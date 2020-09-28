using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InstrumentShopV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Goods_GoodsNumber",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Parts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Ects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Goods_GoodsNumber",
                table: "Parts",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Goods_GoodsNumber",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GoodsNumber",
                table: "Ects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Goods_GoodsNumber",
                table: "Parts",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
