using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm._1_N.Equipo
{
    public class EquipoViewModel
    {
        public int idequipo { get; set; }
        [Required]
        public int idarea { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string area {get;set;}
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }

        
    }
}
