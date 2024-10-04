using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaConocimientoController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public AreaConocimientoController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/AreaConocimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaConocimiento>>> GetAreasConocimiento()
        {
            return await _context.AreasConocimiento
                                 .Where(ac => !ac.IsDeleted) // Solo traer registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/AreaConocimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaConocimiento>> GetAreaConocimiento(int id)
        {
            var areaConocimiento = await _context.AreasConocimiento
                                                 .Where(ac => ac.Id == id && !ac.IsDeleted) // Verifica que no esté borrado
                                                 .FirstOrDefaultAsync();

            if (areaConocimiento == null)
            {
                return NotFound();
            }

            return areaConocimiento;
        }

        // POST: api/AreaConocimiento
        [HttpPost]
        public async Task<ActionResult<AreaConocimiento>> PostAreaConocimiento(AreaConocimiento areaConocimiento)
        {
            _context.AreasConocimiento.Add(areaConocimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaConocimiento", new { id = areaConocimiento.Id }, areaConocimiento);
        }

        // PUT: api/AreaConocimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaConocimiento(int id, AreaConocimiento areaConocimiento)
        {
            if (id != areaConocimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaConocimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaConocimientoExists(id))
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

        // DELETE: api/AreaConocimiento/5 (Borrado lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaConocimiento(int id)
        {
            var areaConocimiento = await _context.AreasConocimiento.FindAsync(id);
            if (areaConocimiento == null)
            {
                return NotFound();
            }

            // Borrado lógico
            areaConocimiento.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaConocimientoExists(int id)
        {
            return _context.AreasConocimiento.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
