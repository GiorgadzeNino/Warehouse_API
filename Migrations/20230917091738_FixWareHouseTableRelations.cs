using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class FixWareHouseTableRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_WareHouse_WareHouseId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Product_WareHouseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Product",
                newName: "CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "WareHouseId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Product_ProductId",
                table: "WareHouse",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Product_ProductId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Product",
                newName: "countryId");

            migrationBuilder.AlterColumn<int>(
                name: "WareHouseId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_WareHouseId",
                table: "Product",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_WareHouse_WareHouseId",
                table: "Product",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id");
        }
    }
}
