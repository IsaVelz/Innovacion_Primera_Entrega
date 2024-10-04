using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarInnovacionController : ControllerBase
    {
        private readonly InnovacionContext _context;

        public CarInnovacionController(InnovacionContext context)
        {
            _context = context;
        }

        // GET: api/CarInnovacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInnovacion>>> GetCarInnovaciones()
        {
            return await _context.CarInnovaciones
                                 .Where(ci => !ci.IsDeleted) // Solo trae registros que no estén marcados como borrados
                                 .ToListAsync();
        }

        // GET: api/CarInnovacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInnovacion>> GetCarInnovacion(int id)
        {
            var carInnovacion = await _context.CarInnovaciones
                                              .Where(ci => ci.Id == id && !ci.IsDeleted) // Verifica que no esté borrado
                                              .FirstOrDefaultAsync();

            if (carInnovacion == null)
            {
                return NotFound();
            }

            return carInnovacion;
        }

        // POST: api/CarInnovacion
        [HttpPost]
        public async Task<ActionResult<CarInnovacion>> PostCarInnovacion(CarInnovacion carInnovacion)
        {
            _context.CarInnovaciones.Add(carInnovacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarInnovacion", new { id = carInnovacion.Id }, carInnovacion);
        }

        // PUT: api/CarInnovacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInnovacion(int id, CarInnovacion carInnovacion)
        {
            if (id != carInnovacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(carInnovacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInnovacionExists(id))
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

        // DELETE: api/CarInnovacion/5 (Borrado lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInnovacion(int id)
        {
            var carInnovacion = await _context.CarInnovaciones.FindAsync(id);
            if (carInnovacion == null)
            {
                return NotFound();
            }

            // Borrado lógico
            carInnovacion.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarInnovacionExists(int id)
        {
            return _context.CarInnovaciones.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
