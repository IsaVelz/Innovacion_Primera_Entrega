using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Aliado
    {
        [Key]
        public int Nit { get; set; }

        [MaxLength(45)]
        public required string RazonSocial { get; set; }

        [MaxLength(45)]
        public required string NombreContacto { get; set; }

        [MaxLength(45)]
        public required string Correo { get; set; }

        [MaxLength(45)]
        public required string Telefono { get; set; }

        [MaxLength(45)]
        public required string Ciudad { get; set; }
        public bool IsDeleted { get; set; } = false; // Nuevo campo para el borrado lógico
    }
}
