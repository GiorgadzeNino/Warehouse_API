using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class addRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersRelationships_RelationshipTypes_RelationshipTypesId",
                table: "CustomersRelationships");

            migrationBuilder.DropIndex(
                name: "IX_CustomersRelationships_RelationshipTypesId",
                table: "CustomersRelationships");

            migrationBuilder.DropColumn(
                name: "RelationshipTypesId",
                table: "CustomersRelationships");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRelationships_RelationshipTypeId",
                table: "CustomersRelationships",
                column: "RelationshipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersRelationships_RelationshipTypes_RelationshipTypeId",
                table: "CustomersRelationships",
                column: "RelationshipTypeId",
                principalTable: "RelationshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersRelationships_RelationshipTypes_RelationshipTypeId",
                table: "CustomersRelationships");

            migrationBuilder.DropIndex(
                name: "IX_CustomersRelationships_RelationshipTypeId",
                table: "CustomersRelationships");

            migrationBuilder.AddColumn<int>(
                name: "RelationshipTypesId",
                table: "CustomersRelationships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRelationships_RelationshipTypesId",
                table: "CustomersRelationships",
                column: "RelationshipTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersRelationships_RelationshipTypes_RelationshipTypesId",
                table: "CustomersRelationships",
                column: "RelationshipTypesId",
                principalTable: "RelationshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
