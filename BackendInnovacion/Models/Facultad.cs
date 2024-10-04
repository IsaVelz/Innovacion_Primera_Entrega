using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class Facultad
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public required string Nombre { get; set; }

        [MaxLength(45)]
        public required string Tipo { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaFun { get; set; }

        // Relación con Universidad
        [ForeignKey("Universidad")]
        public int UniversidadId { get; set; }
        public required Universidad Universidad { get; set; }
    }
}
