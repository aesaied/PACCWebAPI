using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    PCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.PCId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CatId",
                        column: x => x.CatId,
                        principalTable: "ProductCategories",
                        principalColumn: "PCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "PCId", "Name" },
                values: new object[,]
                {
                    { 1, "Mobiles" },
                    { 2, "Printers" },
                    { 3, "Computers" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Samsung S24 Ultra" },
                    { 2, 2, null, "HP Laserjet 3025" },
                    { 3, 3, null, "HP ProBook 15588" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatId",
                table: "Products",
                column: "CatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
