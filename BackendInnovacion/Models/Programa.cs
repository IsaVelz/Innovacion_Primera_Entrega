using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Programa
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public required string Nombre { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [MaxLength(45)]
        public required string Nivel { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaCreacion { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FechaCierre { get; set; }  // Nullable if a program might not have a closure date yet

        public int NumeroCohortes { get; set; }
        public int CantGraduados { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaActualizacion { get; set; }

        [MaxLength(45)]
        public required string Ciudad { get; set; }

        // Relación con Facultad
        [ForeignKey("Facultad")]
        public int FacultadId { get; set; }
        public required Facultad Facultad { get; set; }
    }
}
