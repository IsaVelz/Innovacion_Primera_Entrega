using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspectoNormativoController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public AspectoNormativoController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/AspectoNormativo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspectoNormativo>>> GetAspectosNormativos()
        {
            return await _context.AspectosNormativos
                                 .Where(an => !an.IsDeleted) // Solo traer registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/AspectoNormativo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspectoNormativo>> GetAspectoNormativo(int id)
        {
            var aspectoNormativo = await _context.AspectosNormativos
                                                 .Where(an => an.Id == id && !an.IsDeleted) // Verifica que no esté borrado
                                                 .FirstOrDefaultAsync();

            if (aspectoNormativo == null)
            {
                return NotFound();
            }

            return aspectoNormativo;
        }

        // POST: api/AspectoNormativo
        [HttpPost]
        public async Task<ActionResult<AspectoNormativo>> PostAspectoNormativo(AspectoNormativo aspectoNormativo)
        {
            _context.AspectosNormativos.Add(aspectoNormativo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAspectoNormativo", new { id = aspectoNormativo.Id }, aspectoNormativo);
        }

        // PUT: api/AspectoNormativo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspectoNormativo(int id, AspectoNormativo aspectoNormativo)
        {
            if (id != aspectoNormativo.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspectoNormativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspectoNormativoExists(id))
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

        // DELETE: api/AspectoNormativo/5 (Borrado lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspectoNormativo(int id)
        {
            var aspectoNormativo = await _context.AspectosNormativos.FindAsync(id);
            if (aspectoNormativo == null)
            {
                return NotFound();
            }

            // Borrado lógico
            aspectoNormativo.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspectoNormativoExists(int id)
        {
            return _context.AspectosNormativos.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
