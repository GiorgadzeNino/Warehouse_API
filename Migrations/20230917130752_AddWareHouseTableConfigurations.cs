using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class AddWareHouseTableConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Suppliers_SuppliersId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_SuppliersId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_Units_WareHouseId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SuppliersId",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SupplierId",
                table: "WareHouse",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_UnitId",
                table: "WareHouse",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Suppliers_SupplierId",
                table: "WareHouse",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Units_UnitId",
                table: "WareHouse",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Suppliers_SupplierId",
                table: "WareHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Units_UnitId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_SupplierId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_UnitId",
                table: "WareHouse");

            migrationBuilder.AddColumn<int>(
                name: "SuppliersId",
                table: "WareHouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SuppliersId",
                table: "WareHouse",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_WareHouseId",
                table: "Units",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Suppliers_SuppliersId",
                table: "WareHouse",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
