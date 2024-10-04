using BackendInnovacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInnovacion.Controllers
{
    // Define la ruta base para este controlador como 'api/Universidad'
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadController : ControllerBase
    {
        private readonly InnovacionContext _context;

        // Constructor que inyecta el contexto de la base de datos a través de dependencia
        public UniversidadController(InnovacionContext context)
        {
            _context = context;
        }
        // GET: api/Universidad
        // Obtiene una lista de todas las universidades que no están marcadas como borradas (borrado lógico).
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidades()
        {
            // Consulta a la base de datos, filtrando por universidades no borrada
            return await _context.Universidades
                                 .Where(u => !u.IsDeleted) // Solo trae universidades que no estén marcadas como borradas
                                 .ToListAsync();
        }

        // GET: api/Universidad/5
        // Obtiene una universidad específica por su ID, siempre que no esté marcada como borrada.
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            // Busca la universidad con el ID solicitado que no esté marcada como borrada
            var universidad = await _context.Universidades
                                            .Where(u => u.Id == id && !u.IsDeleted)
                                            .FirstOrDefaultAsync();

            // Si no existe, retorna un 404 (No encontrado)
            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // POST: api/Universidad
        // Crea una nueva universidad en la base de datos.
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            // Añade la nueva universidad al contexto y guarda los cambios en la base de datos
            _context.Universidades.Add(universidad);
            await _context.SaveChangesAsync();

            // Retorna un código 201 (Creado) con la ubicación de la nueva universidad
            return CreatedAtAction("GetUniversidad", new { id = universidad.Id }, universidad);
        }

        // PUT: api/Universidad/5
        // Actualiza una universidad existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            // Verifica si el ID de la URL coincide con el ID del objeto universidad
            if (id != universidad.Id)
            {
                return BadRequest();    // Retorna un error 400 si no coinciden
            }

            // Marca el estado de la universidad como modificado para que EF Core lo tenga en cuenta
            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si la universidad aún existe en la base de datos
                if (!UniversidadExists(id))
                {
                    return NotFound();  // Si no existe, retorna un 404
                }
                else
                {
                    throw;  // Si otro error ocurre, lanza la excepción
                }
            }

            // Retorna un código 204 (No Content) indicando que la actualización fue exitosa
            return NoContent();
        }

        // DELETE: api/Universidad/5 (Borrado lógico)
        // Realiza el borrado lógico de una universidad, marcándola como eliminada sin borrarla físicamente de la base de datos.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidad(int id)
        {
            // Busca la universidad por ID
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();  // Retorna un 404 si no existe.
            }

            // Marca la universidad como borrada (borrado lógico).
            universidad.IsDeleted = true;
            await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos.

            // Retorna un código 204 (No Content) indicando que la eliminación fue exitosa
            return NoContent();
        }

        // Verifica si existe una universidad activa con el ID proporcionado.
        private bool UniversidadExists(int id)
        {
            // Verifica si la universidad existe en la base de datos y no está marcada como borrada
            return _context.Universidades.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
