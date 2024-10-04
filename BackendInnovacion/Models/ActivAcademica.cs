using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class ActivAcademica
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        public required string Nombre { get; set; }

        public int NumCreditos { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [MaxLength(45)]
        public required string AreaFormacion { get; set; }

        public int Hacom { get; set; }
        public int Hindep { get; set; }

        [MaxLength(45)]
        public required string Idioma { get; set; }

        public int? Espejo { get; set; } // Nullable, as it may not always have a value

        [MaxLength(45)]
        public string? EntidadEspejo { get; set; } // Nullable field

        [MaxLength(45)]
        public string? PaisEspejo { get; set; } // Nullable field

        public int Diseno { get; set; }

        // Relación con Programa
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
    }
}
