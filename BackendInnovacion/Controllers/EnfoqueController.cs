using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfoqueController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public EnfoqueController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/Enfoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfoque>>> GetEnfoques()
        {
            return await _context.Enfoques
                                 .Where(e => !e.IsDeleted) // Solo traer registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/Enfoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfoque>> GetEnfoque(int id)
        {
            var enfoque = await _context.Enfoques
                                        .Where(e => e.Id == id && !e.IsDeleted) // Verifica que no esté borrado
                                        .FirstOrDefaultAsync();

            if (enfoque == null)
            {
                return NotFound();
            }

            return enfoque;
        }

        // POST: api/Enfoque
        [HttpPost]
        public async Task<ActionResult<Enfoque>> PostEnfoque(Enfoque enfoque)
        {
            _context.Enfoques.Add(enfoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnfoque", new { id = enfoque.Id }, enfoque);
        }

        // PUT: api/Enfoque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfoque(int id, Enfoque enfoque)
        {
            if (id != enfoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(enfoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfoqueExists(id))
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

        // DELETE: api/Enfoque/5 (Borrado lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfoque(int id)
        {
            var enfoque = await _context.Enfoques.FindAsync(id);
            if (enfoque == null)
            {
                return NotFound();
            }

            // Borrado lógico
            enfoque.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfoqueExists(int id)
        {
            return _context.Enfoques.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
