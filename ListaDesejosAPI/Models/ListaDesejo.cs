using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Models
{
    public class ListaDesejo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListaDesejoId { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

    }
}
