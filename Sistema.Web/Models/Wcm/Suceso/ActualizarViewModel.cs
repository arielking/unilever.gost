﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm.Suceso
{
    public class ActualizarViewModel
    {
        [Required]
        public int idsucesorelac { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
    }
}
