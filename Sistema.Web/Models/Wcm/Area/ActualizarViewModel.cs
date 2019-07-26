﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Wcm.Area
{
    public class ActualizarViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
    }
}
