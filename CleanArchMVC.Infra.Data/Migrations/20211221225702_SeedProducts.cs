using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(DS_NAME, DS_DESCRIPTION, VL_PRICE, QTY_STOCK, DS_IMAGE, ID_CATEGORY)" + "VALUES('CADERNO ESPIRAL', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.png', 1)");

            migrationBuilder.Sql("INSERT INTO Products(DS_NAME, DS_DESCRIPTION, VL_PRICE, QTY_STOCK, DS_IMAGE, ID_CATEGORY)" + "VALUES('ESTOJO ESCOLAR', 'Estojo escolar cinza', 5.65, 70, 'estojo.png', 1)");

            migrationBuilder.Sql("INSERT INTO Products(DS_NAME, DS_DESCRIPTION, VL_PRICE, QTY_STOCK, DS_IMAGE, ID_CATEGORY)" + "VALUES('CALCULADORA', 'Calculadora simples', 15.39, 20, 'calculadora.png', 2)");

            migrationBuilder.Sql("INSERT INTO Products(DS_NAME, DS_DESCRIPTION, VL_PRICE, QTY_STOCK, DS_IMAGE, ID_CATEGORY)" + "VALUES('BORRACHA ESCOLAR', 'borracha escolar preta', 3.25, 80, 'borracha.png', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
