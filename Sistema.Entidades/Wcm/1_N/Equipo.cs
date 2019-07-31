
using System.ComponentModel.DataAnnotations;


namespace Sistema.Entidades.Wcm._1_N
{
    public class Equipo
    {
        public int idequipo { get; set; }
        [Required]
        public int idarea { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")] 
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }

        public Area area { get; set; }
    }
}
