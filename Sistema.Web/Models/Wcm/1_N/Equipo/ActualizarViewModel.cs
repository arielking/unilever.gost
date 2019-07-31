
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Wcm._1_N.Equipo
{
    public class ActualizarViewModel
    {
        [Required]
        public int idequipo { get; set; }
        [Required]
        public int idarea { get; set; }
        [StringLength(50, MinimumLength = 3, 
            ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
