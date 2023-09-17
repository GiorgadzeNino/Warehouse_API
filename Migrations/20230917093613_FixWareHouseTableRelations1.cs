using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class FixWareHouseTableRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_ProductId",
                table: "WareHouse",
                column: "ProductId",
                unique: true);
        }
    }
}
