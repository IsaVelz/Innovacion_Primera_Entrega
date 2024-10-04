using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Universidad
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public required string Nombre { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [MaxLength(45)]
        public required string Ciudad { get; set; }
        // Propiedad agregada para el borrado lógico
        public bool IsDeleted { get; set; } = false;
    }
}