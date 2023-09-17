using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class FixCustomerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Cities_CitiesId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Countries_CountriesId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CitiesId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CountriesId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CountriesId",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Customer",
                type: "nvarchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Customer",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityId",
                table: "Customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountryId",
                table: "Customer",
                column: "CountryId");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_BirthDate_Age",
                table: "Customer",
                sql: "DATEDIFF(YEAR, BirthDate, GETDATE()) >= 18");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Cities_CityId",
                table: "Customer",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Countries_CountryId",
                table: "Customer",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Cities_CityId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Countries_CountryId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CityId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CountryId",
                table: "Customer");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_BirthDate_Age",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountriesId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CitiesId",
                table: "Customer",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountriesId",
                table: "Customer",
                column: "CountriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Cities_CitiesId",
                table: "Customer",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Countries_CountriesId",
                table: "Customer",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
