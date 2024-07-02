using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMME.Models;

namespace PruebaMME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegtipoDocumentoController : ControllerBase
    {
        private readonly DefaultConnection _context;

        public NegtipoDocumentoController(DefaultConnection context)
        {
            _context = context;
        }

        // GET: api/NegtipoDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NegtipoDocumento>>> GetNegtipoDocumento()
        {
            return await _context.NegtipoDocumento.OrderBy(t => t.Orden).Where(f => f.Activo == true).ToListAsync();
        }

        // GET: api/NegtipoDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NegtipoDocumento>> GetNegtipoDocumento(int id)
        {
            var negtipoDocumento = await _context.NegtipoDocumento.FindAsync(id);

            if (negtipoDocumento == null)
            {
                return NotFound();
            }

            return negtipoDocumento;
        }

        // PUT: api/NegtipoDocumento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegtipoDocumento(int id, NegtipoDocumento negtipoDocumento)
        {
            if (id != negtipoDocumento.Id)
            {
                return BadRequest();
            }

            _context.Entry(negtipoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegtipoDocumentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NegtipoDocumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NegtipoDocumento>> PostNegtipoDocumento(NegtipoDocumento negtipoDocumento)
        {
            _context.NegtipoDocumento.Add(negtipoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegtipoDocumento", new { id = negtipoDocumento.Id }, negtipoDocumento);
        }

        // DELETE: api/NegtipoDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegtipoDocumento(int id)
        {
            var negtipoDocumento = await _context.NegtipoDocumento.FindAsync(id);
            if (negtipoDocumento == null)
            {
                return NotFound();
            }

            _context.NegtipoDocumento.Remove(negtipoDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegtipoDocumentoExists(int id)
        {
            return _context.NegtipoDocumento.Any(e => e.Id == id);
        }
    }
}
