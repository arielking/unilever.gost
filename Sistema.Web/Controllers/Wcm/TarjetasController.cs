using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.Tarjeta;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TarjetasController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Tarjetas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TarjetaModel>> Listar()
        {
            var tarjeta = await _context.Tarjetas.ToListAsync();

            return tarjeta.Select(c => new TarjetaModel
            {
                id = c.id,
                nombre = c.nombre,
              
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/Tarjetas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var tarjeta = await _context.Tarjetas.FindAsync(id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            return Ok(new TarjetaModel
            {
                id = tarjeta.id,
                nombre = tarjeta.nombre,
                activo = tarjeta.activo,
                eliminado = tarjeta.eliminado
            });
        }


        // PUT: api/Tarjetas/Actualizar
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

            var tarjeta = await _context.Tarjetas.FirstOrDefaultAsync(c => c.id == model.id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            tarjeta.nombre = model.nombre;
            
          
           

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

            Tarjeta tarjeta = new Tarjeta
            {
                nombre = model.nombre,
         
                activo = true,
                eliminado = false
            };

            _context.Tarjetas.Add(tarjeta);
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

        // DELETE: api/Tarjetas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarjeta = await _context.Tarjetas.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            _context.Tarjetas.Remove(tarjeta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(tarjeta);
        }

        // PUT: api/Tarjetas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tarjeta = await _context.Tarjetas.FirstOrDefaultAsync(c => c.id == id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            tarjeta.activo = false;

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

            var tarjeta = await _context.Tarjetas.FirstOrDefaultAsync(c => c.id == id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            tarjeta.activo = true;

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
