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
    public class DetalhesDoLocalsController : ControllerBase
    {
        private readonly mydbContext _context;

        public DetalhesDoLocalsController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/DetalhesDoLocals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhesDoLocal>>> GetDetalhesDoLocals()
        {
            return await _context.DetalhesDoLocals.ToListAsync();
        }

        // GET: api/DetalhesDoLocals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesDoLocal>> GetDetalhesDoLocal(int id)
        {
            var detalhesDoLocal = await _context.DetalhesDoLocals.FindAsync(id);

            if (detalhesDoLocal == null)
            {
                return NotFound();
            }

            return detalhesDoLocal;
        }

        // PUT: api/DetalhesDoLocals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhesDoLocal(int id, DetalhesDoLocal detalhesDoLocal)
        {
            if (id != detalhesDoLocal.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalhesDoLocal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalhesDoLocalExists(id))
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

        // POST: api/DetalhesDoLocals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalhesDoLocal>> PostDetalhesDoLocal(DetalhesDoLocal detalhesDoLocal)
        {
            _context.DetalhesDoLocals.Add(detalhesDoLocal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalhesDoLocal", new { id = detalhesDoLocal.Id }, detalhesDoLocal);
        }

        // DELETE: api/DetalhesDoLocals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalhesDoLocal>> DeleteDetalhesDoLocal(int id)
        {
            var detalhesDoLocal = await _context.DetalhesDoLocals.FindAsync(id);
            if (detalhesDoLocal == null)
            {
                return NotFound();
            }

            _context.DetalhesDoLocals.Remove(detalhesDoLocal);
            await _context.SaveChangesAsync();

            return detalhesDoLocal;
        }

        private bool DetalhesDoLocalExists(int id)
        {
            return _context.DetalhesDoLocals.Any(e => e.Id == id);
        }
    }
}
