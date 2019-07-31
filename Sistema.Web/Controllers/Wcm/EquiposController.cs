using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm._1_N;
using Sistema.Web.Models.Wcm._1_N.Equipo;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EquiposController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Equipos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EquipoViewModel>> Listar()
        {
            var equipo = await _context.Equipos.Include(a=>a.area).ToListAsync();

            return equipo.Select(a => new EquipoViewModel
            {
                idequipo = a.idequipo,
                idarea=a.idarea,
                area=a.area.nombre,
                nombre = a.nombre,
                descripcion = a.descripcion,
                activo = a.activo
            });

        }


       
    }
}
