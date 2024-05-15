using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDesejosAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "ProdutoId", "CategoriaId", "Nome", "Preco", "UrlImagem" },
                values: new object[] { 1, 1, "Samsung Galaxy A54 5g 128gb 8gb Branco", 1699m, "https://http2.mlstatic.com/D_NQ_NP_2X_977800-MLU75809065020_042024-F.webp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 1);
        }
    }
}
