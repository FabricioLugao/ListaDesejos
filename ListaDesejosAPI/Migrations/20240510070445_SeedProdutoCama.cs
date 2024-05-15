using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDesejosAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutoCama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "ProdutoId", "CategoriaId", "Nome", "Preco", "UrlImagem" },
                values: new object[] { 2, 2, "Cama Box Casal Colchão D33 Pillow Top", 979m, "https://http2.mlstatic.com/D_NQ_NP_2X_946469-MLU74984259316_032024-F.webp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 2);
        }
    }
}
