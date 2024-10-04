using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class AspectoNormativo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [MaxLength(45)]
        public required string Descripcion { get; set; }

        [MaxLength(45)]
        public required string Fuente { get; set; }
        public bool IsDeleted { get; set; } = false; // Nuevo campo para el borrado lógico
    }
}
