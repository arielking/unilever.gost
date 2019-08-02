using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.Suceso;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucesosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public SucesosController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Suceso/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SucesoViewModel>> Listar()
        {
            var categoria = await _context.Sucesos.ToListAsync();

            return categoria.Select(c => new SucesoViewModel
            {
                idsucesorelac = c.idsucesorelac,
                nombre = c.nombre,
                descripcion = c.descripcion,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/Suceso/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var area = await _context.Sucesos.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(new SucesoViewModel
            {
                idsucesorelac = area.idsucesorelac,
                nombre = area.nombre,
                descripcion = area.descripcion,
                activo = area.activo,
                eliminado = area.eliminado
            });
        }


        // PUT: api/Suceso/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idsucesorelac <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Sucesos.FirstOrDefaultAsync(c => c.idsucesorelac == model.idsucesorelac);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
            categoria.descripcion = model.descripcion;

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

        // POST: api/Suceso/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Suceso suceso = new Suceso
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true,
                eliminado = false
            };

            _context.Sucesos.Add(suceso);
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

        // DELETE: api/Suceso/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Suceso = await _context.Sucesos.FindAsync(id);
            if (Suceso == null)
            {
                return NotFound();
            }

            _context.Sucesos.Remove(Suceso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(Suceso);


        }
        // PUT: api/Suceso/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var suceso = await _context.Sucesos.FirstOrDefaultAsync(c => c.idsucesorelac == id);

            if (suceso == null)
            {
                return NotFound();
            }

            suceso.activo = false;

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

        // PUT: api/Categorias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.Sucesos.FirstOrDefaultAsync(c => c.idsucesorelac == id);

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

