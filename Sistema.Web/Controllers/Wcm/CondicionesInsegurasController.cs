using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm;
using Sistema.Web.Models.Wcm.CondicionInsegura;

namespace Sistema.Web.Controllers.Wcm
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionesInsegurasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CondicionesInsegurasController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/CondicionInsegura/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CondicionInseguraViewModel>> Listar()
        {
            var categoria = await _context.CondicionesInseguras.ToListAsync();

            return categoria.Select(c => new CondicionInseguraViewModel
            {
                idcondinsegura = c.idcondinsegura,
                nombre = c.nombre,
                descripcion = c.descripcion,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }

        // GET: api/CondicionInsegura/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var area = await _context.CondicionesInseguras.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(new CondicionInseguraViewModel
            {
                idcondinsegura = area.idcondinsegura,
                nombre = area.nombre,
                descripcion = area.descripcion,
                activo = area.activo,
                eliminado = area.eliminado
            });
        }


        // PUT: api/CondicionInsegura/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcondinsegura <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.CondicionesInseguras.FirstOrDefaultAsync(c => c.idcondinsegura == model.idcondinsegura);

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

        // POST: api/CondicionInsegura/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CondicionInsegura condInsg = new CondicionInsegura
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true,
                eliminado = false
            };

            _context.CondicionesInseguras.Add(condInsg);
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

        // DELETE: api/CondicionInsegura/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CondicionInsegura = await _context.CondicionesInseguras.FindAsync(id);
            if (CondicionInsegura == null)
            {
                return NotFound();
            }

            _context.CondicionesInseguras.Remove(CondicionInsegura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(CondicionInsegura);


        }
        // PUT: api/CondicionInsegura/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var area = await _context.CondicionesInseguras.FirstOrDefaultAsync(c => c.idcondinsegura == id);

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

            var area = await _context.CondicionesInseguras.FirstOrDefaultAsync(c => c.idcondinsegura == id);

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


