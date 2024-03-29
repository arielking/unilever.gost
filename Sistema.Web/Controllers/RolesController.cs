﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Models.Usuarios.Role;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RolesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();

            return rol.Select(c => new RolViewModel
            {
                idrol = c.idrol,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }
        // GET: api/Categorias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var rol = await _context.Roles.Where(r => r.condicion == true).ToListAsync();

            return rol.Select(r => new SelectViewModel
            {
                idrol = r.idrol,
                nombre = r.nombre
            });

        }
        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.idrol == id);
        }
    }
}
