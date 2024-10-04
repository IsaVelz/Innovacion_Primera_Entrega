using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class RegistroCalificado
    {
        [Key]
        public int Codigo { get; set; }

        public int CantCreditos { get; set; }

        [MaxLength(45)]
        public required string HoraAcom { get; set; }

        [MaxLength(45)]
        public required string HoraInd { get; set; }

        [MaxLength(45)]
        public required string Metodologia { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaFin { get; set; }

        [MaxLength(45)]
        public required string DuracionAños { get; set; }

        [MaxLength(45)]
        public required string DuracionSemestres { get; set; }

        [MaxLength(45)]
        public required string TipoTitulacion { get; set; }

        // Relación con Programa
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
        public required ICollection<AaRc> AaRcs { get; set; }

    }
}
