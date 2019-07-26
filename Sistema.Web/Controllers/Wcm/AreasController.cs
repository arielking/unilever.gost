using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.Area;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AreasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Areas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AreaViewModel>> Listar()
        {
            var categoria = await _context.Areas.ToListAsync();

            return categoria.Select(c => new AreaViewModel
            {
                id = c.id,
                nombre = c.nombre,
                descripcion = c.descripcion,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/Areas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(new AreaViewModel
            {
                id = area.id,
                nombre = area.nombre,
                descripcion = area.descripcion,
                activo = area.activo,
                eliminado = area.eliminado
            });
        }


        // PUT: api/Areas/Actualizar
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

            var categoria = await _context.Areas.FirstOrDefaultAsync(c => c.id == model.id);

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

        // POST: api/Areas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Area area = new Area
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true,
                eliminado = false
            };

            _context.Areas.Add(area);
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

        // DELETE: api/Areas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var areas = await _context.Areas.FindAsync(id);
            if (areas == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(areas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(areas);


        }
        // PUT: api/Areas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.Areas.FirstOrDefaultAsync(c => c.id == id);

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

        // PUT: api/Categorias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.Areas.FirstOrDefaultAsync(c => c.id == id);

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

