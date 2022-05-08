using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImoveisOnline.Models;

namespace ImoveisOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalhesVendumsController : ControllerBase
    {
        private readonly mydbContext _context;

        public DetalhesVendumsController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/DetalhesVendums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhesVendum>>> GetDetalhesVenda()
        {
            return await _context.DetalhesVenda.ToListAsync();
        }

        // GET: api/DetalhesVendums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesVendum>> GetDetalhesVendum(int id)
        {
            var detalhesVendum = await _context.DetalhesVenda.FindAsync(id);

            if (detalhesVendum == null)
            {
                return NotFound();
            }

            return detalhesVendum;
        }

        // PUT: api/DetalhesVendums/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhesVendum(int id, DetalhesVendum detalhesVendum)
        {
            if (id != detalhesVendum.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalhesVendum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalhesVendumExists(id))
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

        // POST: api/DetalhesVendums
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalhesVendum>> PostDetalhesVendum(DetalhesVendum detalhesVendum)
        {
            _context.DetalhesVenda.Add(detalhesVendum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalhesVendum", new { id = detalhesVendum.Id }, detalhesVendum);
        }

        // DELETE: api/DetalhesVendums/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalhesVendum>> DeleteDetalhesVendum(int id)
        {
            var detalhesVendum = await _context.DetalhesVenda.FindAsync(id);
            if (detalhesVendum == null)
            {
                return NotFound();
            }

            _context.DetalhesVenda.Remove(detalhesVendum);
            await _context.SaveChangesAsync();

            return detalhesVendum;
        }

        private bool DetalhesVendumExists(int id)
        {
            return _context.DetalhesVenda.Any(e => e.Id == id);
        }
    }
}
