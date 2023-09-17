using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class AddWareHouseAndSuppliersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuppliersId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuppliersId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealizationPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_WareHouseId",
                table: "Units",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WareHouseId",
                table: "Product",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SuppliersId",
                table: "Countries",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_SuppliersId",
                table: "Cities",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_WareHouseId",
                table: "Suppliers",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Suppliers_SuppliersId",
                table: "Cities",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Suppliers_SuppliersId",
                table: "Countries",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Suppliers_SuppliersId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Suppliers_SuppliersId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_WareHouse_WareHouseId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_WareHouse_WareHouseId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_Units_WareHouseId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Product_WareHouseId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Countries_SuppliersId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_SuppliersId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SuppliersId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "SuppliersId",
                table: "Cities");
        }
    }
}
