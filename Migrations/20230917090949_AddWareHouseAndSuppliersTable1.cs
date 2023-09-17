using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class AddWareHouseAndSuppliersTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_WareHouse_WareHouseId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_WareHouseId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "SuppliersId",
                table: "WareHouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SuppliersId",
                table: "WareHouse",
                column: "SuppliersId");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Suppliers_SuppliersId",
                table: "WareHouse",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Suppliers_SuppliersId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_SuppliersId",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "SuppliersId",
                table: "WareHouse");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_WareHouseId",
                table: "Suppliers",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_WareHouse_WareHouseId",
                table: "Suppliers",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id");
        }
    }
}
