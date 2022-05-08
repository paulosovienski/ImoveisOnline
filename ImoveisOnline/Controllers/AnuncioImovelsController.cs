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
    public class AnuncioImovelsController : ControllerBase
    {
        private readonly mydbContext _context;

        public AnuncioImovelsController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/AnuncioImovels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnuncioImovel>>> GetAnuncioImovels()
        {
            return await _context.AnuncioImovels.ToListAsync();
        }

        // GET: api/AnuncioImovels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnuncioImovel>> GetAnuncioImovel(int id)
        {
            var anuncioImovel = await _context.AnuncioImovels.FindAsync(id);

            if (anuncioImovel == null)
            {
                return NotFound();
            }

            return anuncioImovel;
        }

        // PUT: api/AnuncioImovels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncioImovel(int id, AnuncioImovel anuncioImovel)
        {
            if (id != anuncioImovel.Id)
            {
                return BadRequest();
            }

            _context.Entry(anuncioImovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioImovelExists(id))
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

        // POST: api/AnuncioImovels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnuncioImovel>> PostAnuncioImovel(AnuncioImovel anuncioImovel)
        {
            _context.AnuncioImovels.Add(anuncioImovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnuncioImovel", new { id = anuncioImovel.Id }, anuncioImovel);
        }

        // DELETE: api/AnuncioImovels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnuncioImovel>> DeleteAnuncioImovel(int id)
        {
            var anuncioImovel = await _context.AnuncioImovels.FindAsync(id);
            if (anuncioImovel == null)
            {
                return NotFound();
            }

            _context.AnuncioImovels.Remove(anuncioImovel);
            await _context.SaveChangesAsync();

            return anuncioImovel;
        }

        private bool AnuncioImovelExists(int id)
        {
            return _context.AnuncioImovels.Any(e => e.Id == id);
        }
    }
}
