using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class FixProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategories_ProductCategoriesId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCategoriesId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCategoriesId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Product",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Product",
                newName: "CreateDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategories_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "PersonalNumber");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Product",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Product",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "GenderId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoriesId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoriesId",
                table: "Product",
                column: "ProductCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategories_ProductCategoriesId",
                table: "Product",
                column: "ProductCategoriesId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }
    }
}
