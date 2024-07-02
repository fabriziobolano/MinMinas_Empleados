using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMME.Models;

namespace PruebaMME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegempleadoController : ControllerBase
    {
        private readonly DefaultConnection _context;

        public NegempleadoController(DefaultConnection context)
        {
            _context = context;
        }

        // GET: api/Negempleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negempleado>>> GetNegempleado()
        {
            return await _context.Negempleado.ToListAsync();
        }

        // GET: api/Negempleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negempleado>> GetNegempleado(int id)
        {
            var negempleado = await _context.Negempleado.FindAsync(id);

            if (negempleado == null)
            {
                return NotFound();
            }

            return negempleado;
        }

        // PUT: api/Negempleado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegempleado(int id, Negempleado negempleado)
        {
            if (id != negempleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(negempleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegempleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Negempleado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Negempleado>> PostNegempleado(Negempleado negempleado)
        {
            try
            {
                _context.Negempleado.Add(negempleado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetNegempleado", new { id = negempleado.Id }, negempleado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Negempleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegempleado(int id)
        {
            var negempleado = await _context.Negempleado.FindAsync(id);
            if (negempleado == null)
            {
                return NotFound();
            }

            _context.Negempleado.Remove(negempleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegempleadoExists(int id)
        {
            return _context.Negempleado.Any(e => e.Id == id);
        }


        [HttpPost]
        [Route("PostEliminar/{id}")]
        public async Task<ActionResult<Negempleado>> PostNegempleado(int id, Negempleado negempleado)
        {
            try
            {
                _context.Negempleado.Add(negempleado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetNegempleado", new { id = negempleado.Id }, negempleado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
