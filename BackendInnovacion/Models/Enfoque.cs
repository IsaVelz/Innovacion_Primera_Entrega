using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Enfoque
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        public required string Nombre { get; set; }

        [MaxLength(45)]
        public required string Descripcion { get; set; }
        public bool IsDeleted { get; set; } = false; // Nuevo campo para el borrado lógico
    }
}
