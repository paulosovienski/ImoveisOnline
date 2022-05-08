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
    public class UsuarioRolesController : ControllerBase
    {
        private readonly mydbContext _context;

        public UsuarioRolesController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRole>>> GetUsuarioRoles()
        {
            return await _context.UsuarioRoles.ToListAsync();
        }

        // GET: api/UsuarioRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRole>> GetUsuarioRole(int id)
        {
            var usuarioRole = await _context.UsuarioRoles.FindAsync(id);

            if (usuarioRole == null)
            {
                return NotFound();
            }

            return usuarioRole;
        }

        // PUT: api/UsuarioRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRole(int id, UsuarioRole usuarioRole)
        {
            if (id != usuarioRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRoleExists(id))
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

        // POST: api/UsuarioRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioRole>> PostUsuarioRole(UsuarioRole usuarioRole)
        {
            _context.UsuarioRoles.Add(usuarioRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioRole", new { id = usuarioRole.Id }, usuarioRole);
        }

        // DELETE: api/UsuarioRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioRole>> DeleteUsuarioRole(int id)
        {
            var usuarioRole = await _context.UsuarioRoles.FindAsync(id);
            if (usuarioRole == null)
            {
                return NotFound();
            }

            _context.UsuarioRoles.Remove(usuarioRole);
            await _context.SaveChangesAsync();

            return usuarioRole;
        }

        private bool UsuarioRoleExists(int id)
        {
            return _context.UsuarioRoles.Any(e => e.Id == id);
        }
    }
}
