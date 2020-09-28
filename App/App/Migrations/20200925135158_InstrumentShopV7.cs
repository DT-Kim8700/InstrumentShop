using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InstrumentShopV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Goods_GoodsNumber",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Goods_GoodsNumber",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_GoodsNumber",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_GoodsNumber",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_GoodsNumber",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Ects_GoodsNumber",
                table: "Ects");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Goods",
                newName: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Goods",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Goods",
                newName: "brand");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_GoodsNumber",
                table: "Parts",
                column: "GoodsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_GoodsNumber",
                table: "OrderItems",
                column: "GoodsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_GoodsNumber",
                table: "Instruments",
                column: "GoodsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ects_GoodsNumber",
                table: "Ects",
                column: "GoodsNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Ects_Goods_GoodsNumber",
                table: "Ects",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Goods_GoodsNumber",
                table: "Instruments",
                column: "GoodsNumber",
                principalTable: "Goods",
                principalColumn: "GoodsNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Goods_GoodsNumber",
                table: "OrderItems",
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
    }
}
