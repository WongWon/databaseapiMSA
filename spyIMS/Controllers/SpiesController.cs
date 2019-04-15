using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spyIMS.Model;

namespace spyIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpiesController : ControllerBase
    {
        private readonly spyIMSContext _context;

        public SpiesController(spyIMSContext context)
        {
            _context = context;
        }

        // GET: api/Spies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spies>>> GetSpies()
        {
            return await _context.Spies.ToListAsync();
        }

        // GET: api/Spies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spies>> GetSpies(int id)
        {
            var spies = await _context.Spies.FindAsync(id);

            if (spies == null)
            {
                return NotFound();
            }

            return spies;
        }

        // PUT: api/Spies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpies(int id, Spies spies)
        {
            if (id != spies.Id)
            {
                return BadRequest();
            }

            _context.Entry(spies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpiesExists(id))
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

        // POST: api/Spies
        [HttpPost]
        public async Task<ActionResult<Spies>> PostSpies(Spies spies)
        {
            _context.Spies.Add(spies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpies", new { id = spies.Id }, spies);
        }

        // DELETE: api/Spies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spies>> DeleteSpies(int id)
        {
            var spies = await _context.Spies.FindAsync(id);
            if (spies == null)
            {
                return NotFound();
            }

            _context.Spies.Remove(spies);
            await _context.SaveChangesAsync();

            return spies;
        }

        private bool SpiesExists(int id)
        {
            return _context.Spies.Any(e => e.Id == id);
        }
    }
}
