using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VL_PRICE = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    QTY_STOCK = table.Column<int>(type: "int", nullable: false),
                    DS_IMAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_CATEGORY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ID_CATEGORY",
                        column: x => x.ID_CATEGORY,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DS_NAME" },
                values: new object[] { 1, "Material Escolar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DS_NAME" },
                values: new object[] { 2, "Eletrônicos" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DS_NAME" },
                values: new object[] { 3, "Acessórios" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ID_CATEGORY",
                table: "Products",
                column: "ID_CATEGORY");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
