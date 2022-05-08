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
    public class DetalhesLocacaosController : ControllerBase
    {
        private readonly mydbContext _context;

        public DetalhesLocacaosController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/DetalhesLocacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhesLocacao>>> GetDetalhesLocacaos()
        {
            return await _context.DetalhesLocacaos.ToListAsync();
        }

        // GET: api/DetalhesLocacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesLocacao>> GetDetalhesLocacao(int id)
        {
            var detalhesLocacao = await _context.DetalhesLocacaos.FindAsync(id);

            if (detalhesLocacao == null)
            {
                return NotFound();
            }

            return detalhesLocacao;
        }

        // PUT: api/DetalhesLocacaos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhesLocacao(int id, DetalhesLocacao detalhesLocacao)
        {
            if (id != detalhesLocacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalhesLocacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalhesLocacaoExists(id))
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

        // POST: api/DetalhesLocacaos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalhesLocacao>> PostDetalhesLocacao(DetalhesLocacao detalhesLocacao)
        {
            _context.DetalhesLocacaos.Add(detalhesLocacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalhesLocacao", new { id = detalhesLocacao.Id }, detalhesLocacao);
        }

        // DELETE: api/DetalhesLocacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalhesLocacao>> DeleteDetalhesLocacao(int id)
        {
            var detalhesLocacao = await _context.DetalhesLocacaos.FindAsync(id);
            if (detalhesLocacao == null)
            {
                return NotFound();
            }

            _context.DetalhesLocacaos.Remove(detalhesLocacao);
            await _context.SaveChangesAsync();

            return detalhesLocacao;
        }

        private bool DetalhesLocacaoExists(int id)
        {
            return _context.DetalhesLocacaos.Any(e => e.Id == id);
        }
    }
}
