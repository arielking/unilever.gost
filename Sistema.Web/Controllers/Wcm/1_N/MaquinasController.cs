using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm._1_N;
using Sistema.Web.Models.Wcm._1_N.Maquina;

namespace Sistema.Web.Controllers.Wcm._1_N
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public MaquinasController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Maquinas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<MaquinaViewModel>> Listar()
        {
            var maquina = await _context.Maquinas.Include(a => a.area).ToListAsync();

            return maquina.Select(a => new MaquinaViewModel
            {
                idmaquina = a.idmaquina,
                idarea = a.idarea,
                area = a.area.nombre,
                nombre = a.nombre,
                descripcion = a.descripcion,
                activo = a.activo
            });

        }

        // GET: api/Maquinas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var maquina = await _context.Maquinas.Include(a => a.area).
                SingleOrDefaultAsync(a => a.idmaquina == id);

            if (maquina == null)
            {
                return NotFound();
            }

            return Ok(new MaquinaViewModel
            {
                idmaquina = maquina.idmaquina,
                idarea = maquina.idarea,
                area = maquina.area.nombre,
                nombre = maquina.nombre,
                descripcion = maquina.descripcion,
                activo = maquina.activo
            });
        }

        // PUT: api/Maquinas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idmaquina <= 0)
            {
                return BadRequest();
            }

            var maquina = await _context.Maquinas.FirstOrDefaultAsync(c => c.idmaquina == model.idmaquina);

            if (maquina == null)
            {
                return NotFound();
            }

            maquina.idarea = model.idarea;
            maquina.nombre = model.nombre;
            maquina.descripcion = model.descripcion;

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

        // POST: api/Maquinas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Maquina maquina = new Maquina
            {
                idarea = model.idarea,
                nombre = model.nombre,
                descripcion = model.descripcion,
                activo = true
            };

            _context.Maquinas.Add(maquina);
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
        // PUT: api/Maquinas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var maquina = await _context.Maquinas.FirstOrDefaultAsync(c => c.idmaquina == id);

            if (maquina == null)
            {
                return NotFound();
            }

            maquina.activo = false;

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

        // PUT: api/Maquinas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var maquina = await _context.Maquinas.FirstOrDefaultAsync(c => c.idmaquina == id);

            if (maquina == null)
            {
                return NotFound();
            }

            maquina.activo = true;

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

        private bool MaquinaExists(int id)
        {
            return _context.Maquinas.Any(e => e.idmaquina == id);
        }
    }
}
