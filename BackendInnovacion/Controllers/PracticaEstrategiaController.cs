using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticaEstrategiaController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public PracticaEstrategiaController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/PracticaEstrategia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticaEstrategia>>> GetPracticasEstrategias()
        {
            return await _context.PracticasEstrategias
                                 .Where(pe => !pe.IsDeleted) // Solo traer registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/PracticaEstrategia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticaEstrategia>> GetPracticaEstrategia(int id)
        {
            var practicaEstrategia = await _context.PracticasEstrategias
                                                   .Where(pe => pe.Id == id && !pe.IsDeleted) // Verifica que no esté borrado
                                                   .FirstOrDefaultAsync();

            if (practicaEstrategia == null)
            {
                return NotFound();
            }

            return practicaEstrategia;
        }

        // POST: api/PracticaEstrategia
        [HttpPost]
        public async Task<ActionResult<PracticaEstrategia>> PostPracticaEstrategia(PracticaEstrategia practicaEstrategia)
        {
            _context.PracticasEstrategias.Add(practicaEstrategia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPracticaEstrategia", new { id = practicaEstrategia.Id }, practicaEstrategia);
        }

        // PUT: api/PracticaEstrategia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracticaEstrategia(int id, PracticaEstrategia practicaEstrategia)
        {
            if (id != practicaEstrategia.Id)
            {
                return BadRequest();
            }

            _context.Entry(practicaEstrategia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticaEstrategiaExists(id))
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

        // DELETE: api/PracticaEstrategia/5 (Borrado lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracticaEstrategia(int id)
        {
            var practicaEstrategia = await _context.PracticasEstrategias.FindAsync(id);
            if (practicaEstrategia == null)
            {
                return NotFound();
            }

            // Borrado lógico
            practicaEstrategia.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracticaEstrategiaExists(int id)
        {
            return _context.PracticasEstrategias.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
