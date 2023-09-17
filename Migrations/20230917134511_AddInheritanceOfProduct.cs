using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTUProject.Migrations
{
    public partial class AddInheritanceOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublishingHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingYear = table.Column<int>(type: "int", nullable: false),
                    RecommendedAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Product_Id",
                        column: x => x.Id,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SportInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecommentddedAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportInventory_Product_Id",
                        column: x => x.Id,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Toy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecommendedAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toy_Product_Id",
                        column: x => x.Id,
                        principalTable: "Product",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "SportInventory");

            migrationBuilder.DropTable(
                name: "Toy");
        }
    }
}
