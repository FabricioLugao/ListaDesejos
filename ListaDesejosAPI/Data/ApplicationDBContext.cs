using ListaDesejosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDesejosAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ListaDesejo> ListasDesejos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoriaId = 1,
                    Nome = "Tecnologia"
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Nome = "Casa e móveis"
                },
                new Categoria
                {
                    CategoriaId = 3,
                    Nome = "Esporte e fitness"
                },
                new Categoria
                {
                    CategoriaId = 4,
                    Nome = "Moda"
                },
                new Categoria
                {
                    CategoriaId = 5,
                    Nome = "Saúde"
                });


            builder.Entity<Produto>().HasData(
                new Produto
                {
                    ProdutoId = 1,
                    Nome = "Samsung Galaxy A54 5g 128gb 8gb Branco",
                    Preco = 1699,
                    UrlImagem = "https://http2.mlstatic.com/D_NQ_NP_2X_977800-MLU75809065020_042024-F.webp",
                    CategoriaId = 1
                },
                new Produto
                {
                    ProdutoId = 2,
                    Nome = "Cama Box Casal Colchão D33 Pillow Top",
                    Preco = 979,
                    UrlImagem = "https://http2.mlstatic.com/D_NQ_NP_2X_946469-MLU74984259316_032024-F.webp",
                    CategoriaId = 2
                });
        }
    }
}
