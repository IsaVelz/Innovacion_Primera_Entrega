using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Acreditacion
    {
        [Key]
        public int Resolucion { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [MaxLength(45)]
        public required string Calificacion { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaFin { get; set; }

        // Relación con Programa
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
    }
}
