﻿using Sistema.Entidades.Wcm._1_N;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Wcm
{
   public  class Area
    {
        public int idarea { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }
        public ICollection<Equipo> equipos { get; set; }

    }
}
