using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Pasantia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        public required string Nombre { get; set; }

        [MaxLength(45)]
        public required string Pais { get; set; }

        [MaxLength(45)]
        public required string Empresa { get; set; }

        [MaxLength(45)]
        public required string Descripcion { get; set; }

        // Relación con Programa
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
    }
}
