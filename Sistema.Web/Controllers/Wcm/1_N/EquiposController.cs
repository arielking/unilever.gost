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

        // GET: api/Equipos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var equipo = await _context.Equipos.Include(a=>a.area).
                SingleOrDefaultAsync(a=>a.idequipo==id);

            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(new EquipoViewModel
            {
                idequipo = equipo.idequipo,
                idarea=equipo.idarea,
                area=equipo.area.nombre,
                nombre = equipo.nombre,
                descripcion = equipo.descripcion,
                activo = equipo.activo
            });
        }

        // PUT: api/Equipos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idequipo <= 0)
            {
                return BadRequest();
            }

            var equipo = await _context.Equipos.FirstOrDefaultAsync(c => c.idequipo == model.idequipo);

            if (equipo == null)
            {
                return NotFound();
            }

            equipo.idarea = model.idarea;
            equipo.nombre = model.nombre;
            equipo.descripcion = model.descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Equipos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Equipo equipo = new Equipo
            {
                idarea = model.idarea,
                nombre=model.nombre,
                descripcion = model.descripcion,
                activo = true
            };

            _context.Equipos.Add(equipo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Equipos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var equipo = await _context.Equipos.FirstOrDefaultAsync(c => c.idequipo == id);

            if (equipo == null)
            {
                return NotFound();
            }

            equipo.activo = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Equipos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var equipo = await _context.Equipos.FirstOrDefaultAsync(c => c.idequipo == id);

            if (equipo == null)
            {
                return NotFound();
            }

            equipo.activo = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }
        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.idequipo == id);
        }
    }
}
