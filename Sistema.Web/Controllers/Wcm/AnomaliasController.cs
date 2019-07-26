using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.Anomalia;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnomaliasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AnomaliasController(DbContextSistema context)
        {
            _context = context;
        }


        // GET: api/Anomalias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AnomaliaModel>> Listar()
        {
            var categoria = await _context.Anomalias.ToListAsync();

            return categoria.Select(c => new AnomaliaModel
            {
                id = c.id,
                nombre = c.nombre,
                descripcion = c.descripcion,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/Anomalias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var anomalia = await _context.Anomalias.FindAsync(id);

            if (anomalia == null)
            {
                return NotFound();
            }

            return Ok(new AnomaliaModel
            {
                id = anomalia.id,
                nombre = anomalia.nombre,
                descripcion = anomalia.descripcion,
                activo = anomalia.activo,
                eliminado = anomalia.eliminado
            });
        }


        // PUT: api/Anomalias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }

            var anomalia = await _context.Anomalias.FirstOrDefaultAsync(c => c.id == model.id);

            if (anomalia == null)
            {
                return NotFound();
            }

            anomalia.nombre = model.nombre;
            anomalia.descripcion = model.descripcion;
           

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

        // POST: api/Anomalias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Anomalia anomalia = new Anomalia
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true,
                eliminado = false
            };

            _context.Anomalias.Add(anomalia);
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

        // DELETE: api/Anomalias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anomalia = await _context.Anomalias.FindAsync(id);
            if (anomalia == null)
            {
                return NotFound();
            }

            _context.Anomalias.Remove(anomalia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(anomalia);
        }
        // PUT: api/Anomalias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var anomalia = await _context.Anomalias.FirstOrDefaultAsync(c => c.id == id);

            if (anomalia == null)
            {
                return NotFound();
            }

            anomalia.activo = false;

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

        // PUT: api/Anomalias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var anomalia = await _context.Anomalias.FirstOrDefaultAsync(c => c.id == id);

            if (anomalia == null)
            {
                return NotFound();
            }

            anomalia.activo = true;

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
