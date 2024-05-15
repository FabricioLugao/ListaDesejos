using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Models.Dto
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [Precision(18, 2)]
        public decimal? Preco { get; set; }

        public string UrlImagem { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }
}
