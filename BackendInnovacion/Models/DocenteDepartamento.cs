using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class DocenteDepartamento
    {
        [Key, Column(Order = 0)]
        public int DocenteId { get; set; }

        [Key, Column(Order = 1)]
        public int DepartamentoId { get; set; }

        [MaxLength(45)]
        public required string Dedicacion { get; set; }

        [MaxLength(45)]
        public required string Modalidad { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaIngreso { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FechaSalida { get; set; } 

        // Relación con Programa
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
    }
}
