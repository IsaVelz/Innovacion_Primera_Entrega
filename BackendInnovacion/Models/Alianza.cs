using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Alianza
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Aliado")]
        public int AliadoId { get; set; }
        public required Aliado Aliado { get; set; }

        [Key, Column(Order = 1)]
        public int DepartamentoId { get; set; }

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
