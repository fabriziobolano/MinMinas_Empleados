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
    public class NegoficinaController : ControllerBase
    {
        private readonly DefaultConnection _context;

        public NegoficinaController(DefaultConnection context)
        {
            _context = context;
        }

        // GET: api/Negoficina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negoficina>>> GetNegoficina()
        {
            return await _context.Negoficina.ToListAsync();
        }

        // GET: api/Negoficina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negoficina>> GetNegoficina(int id)
        {
            var negoficina = await _context.Negoficina.FindAsync(id);

            if (negoficina == null)
            {
                return NotFound();
            }

            return negoficina;
        }

        // PUT: api/Negoficina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegoficina(int id, Negoficina negoficina)
        {
            if (id != negoficina.Id)
            {
                return BadRequest();
            }

            _context.Entry(negoficina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegoficinaExists(id))
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

        // POST: api/Negoficina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Negoficina>> PostNegoficina(Negoficina negoficina)
        {
            _context.Negoficina.Add(negoficina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegoficina", new { id = negoficina.Id }, negoficina);
        }

        // DELETE: api/Negoficina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegoficina(int id)
        {
            var negoficina = await _context.Negoficina.FindAsync(id);
            if (negoficina == null)
            {
                return NotFound();
            }

            _context.Negoficina.Remove(negoficina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegoficinaExists(int id)
        {
            return _context.Negoficina.Any(e => e.Id == id);
        }
    }
}
