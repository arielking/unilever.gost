﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public int idrol { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] password_salt { get; set; }
        public bool condicion { get; set; }

        public Rol rol { get; set; }



    }
}
