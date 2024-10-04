using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliadoController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public AliadoController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/Aliado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aliado>>> GetAliados()
        {
            return await _context.Aliados
                                 .Where(a => !a.IsDeleted) // Solo traer registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/Aliado/5
        [HttpGet("{nit}")]
        public async Task<ActionResult<Aliado>> GetAliado(int nit)
        {
            var aliado = await _context.Aliados
                                       .Where(a => a.Nit == nit && !a.IsDeleted) // Verifica que no esté borrado
                                       .FirstOrDefaultAsync();

            if (aliado == null)
            {
                return NotFound();
            }

            return aliado;
        }

        // POST: api/Aliado
        [HttpPost]
        public async Task<ActionResult<Aliado>> PostAliado(Aliado aliado)
        {
            _context.Aliados.Add(aliado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAliado", new { nit = aliado.Nit }, aliado);
        }

        // PUT: api/Aliado/5
        [HttpPut("{nit}")]
        public async Task<IActionResult> PutAliado(int nit, Aliado aliado)
        {
            if (nit != aliado.Nit)
            {
                return BadRequest();
            }

            _context.Entry(aliado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AliadoExists(nit))
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

        // DELETE: api/Aliado/5 (Borrado lógico)
        [HttpDelete("{nit}")]
        public async Task<IActionResult> DeleteAliado(int nit)
        {
            var aliado = await _context.Aliados.FindAsync(nit);
            if (aliado == null)
            {
                return NotFound();
            }

            // Borrado lógico
            aliado.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AliadoExists(int nit)
        {
            return _context.Aliados.Any(e => e.Nit == nit && !e.IsDeleted);
        }
    }
}
