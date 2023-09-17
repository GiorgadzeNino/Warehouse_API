using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class ChangeCustomerAndRelationshipsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersRelationships_Customer_CustomerId",
                table: "CustomersRelationships");

            migrationBuilder.DropIndex(
                name: "IX_CustomersRelationships_CustomerId",
                table: "CustomersRelationships");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomersRelationships");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRelationships_EndCustomerId",
                table: "CustomersRelationships",
                column: "EndCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRelationships_StartCustomerId",
                table: "CustomersRelationships",
                column: "StartCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersRelationships_Customer_EndCustomerId",
                table: "CustomersRelationships",
                column: "EndCustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersRelationships_Customer_StartCustomerId",
                table: "CustomersRelationships",
                column: "StartCustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersRelationships_Customer_EndCustomerId",
                table: "CustomersRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersRelationships_Customer_StartCustomerId",
                table: "CustomersRelationships");

            migrationBuilder.DropIndex(
                name: "IX_CustomersRelationships_EndCustomerId",
                table: "CustomersRelationships");

            migrationBuilder.DropIndex(
                name: "IX_CustomersRelationships_StartCustomerId",
                table: "CustomersRelationships");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomersRelationships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRelationships_CustomerId",
                table: "CustomersRelationships",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersRelationships_Customer_CustomerId",
                table: "CustomersRelationships",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
