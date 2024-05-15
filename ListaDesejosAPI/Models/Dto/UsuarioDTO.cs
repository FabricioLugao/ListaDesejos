using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Models.Dto
{
    public class UsuarioDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
