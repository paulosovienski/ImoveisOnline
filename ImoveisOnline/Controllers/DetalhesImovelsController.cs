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
    public class DetalhesImovelsController : ControllerBase
    {
        private readonly MydbContext _context;

        public DetalhesImovelsController(MydbContext context)
        {
            _context = context;
        }

        // GET: api/DetalhesImovels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhesImovel>>> GetDetalhesImovels()
        {
            return await _context.DetalhesImovels.ToListAsync();
        }

        // GET: api/DetalhesImovels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesImovel>> GetDetalhesImovel(int id)
        {
            var detalhesImovel = await _context.DetalhesImovels.FindAsync(id);

            if (detalhesImovel == null)
            {
                return NotFound();
            }

            return detalhesImovel;
        }

        // PUT: api/DetalhesImovels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhesImovel(int id, DetalhesImovel detalhesImovel)
        {
            if (id != detalhesImovel.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalhesImovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalhesImovelExists(id))
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

        // POST: api/DetalhesImovels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalhesImovel>> PostDetalhesImovel(DetalhesImovel detalhesImovel)
        {
            _context.DetalhesImovels.Add(detalhesImovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalhesImovel", new { id = detalhesImovel.Id }, detalhesImovel);
        }

        // DELETE: api/DetalhesImovels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalhesImovel>> DeleteDetalhesImovel(int id)
        {
            var detalhesImovel = await _context.DetalhesImovels.FindAsync(id);
            if (detalhesImovel == null)
            {
                return NotFound();
            }

            _context.DetalhesImovels.Remove(detalhesImovel);
            await _context.SaveChangesAsync();

            return detalhesImovel;
        }

        private bool DetalhesImovelExists(int id)
        {
            return _context.DetalhesImovels.Any(e => e.Id == id);
        }
    }
}
