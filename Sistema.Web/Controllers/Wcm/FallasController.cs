using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.Falla;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class FallasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public FallasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Falla/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<FallaViewModel>> Listar()
        {
            var falla = await _context.Fallas.ToListAsync();

            return falla.Select(c => new FallaViewModel
            {
                idfalla = c.idfalla,
                nombre = c.nombre,
                descripcion = c.descripcion,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/Falla/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var area = await _context.Fallas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(new FallaViewModel
            {
                idfalla = area.idfalla,
                nombre = area.nombre,
                descripcion = area.descripcion,
                activo = area.activo,
                eliminado = area.eliminado
            });
        }


        // PUT: api/Falla/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idfalla <= 0)
            {
                return BadRequest();
            }

            var falla = await _context.Fallas.FirstOrDefaultAsync(c => c.idfalla == model.idfalla);

            if (falla == null)
            {
                return NotFound();
            }

            falla.nombre = model.nombre;
            falla.descripcion = model.descripcion;

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

        // POST: api/Falla/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Falla falla = new Falla
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true,
                eliminado = false
            };

            _context.Fallas.Add(falla);
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

        // DELETE: api/Falla/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Falla = await _context.Fallas.FindAsync(id);
            if (Falla == null)
            {
                return NotFound();
            }

            _context.Fallas.Remove(Falla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(Falla);


        }
        // PUT: api/Falla/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.Fallas.FirstOrDefaultAsync(c => c.idfalla == id);

            if (area == null)
            {
                return NotFound();
            }

            area.activo = false;

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

        // PUT: api/fallas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.Fallas.FirstOrDefaultAsync(c => c.idfalla == id);

            if (area == null)
            {
                return NotFound();
            }

            area.activo = true;

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



    }
}
