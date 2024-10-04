using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class ProgramaCI
    {
        [Key]
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }

        [ForeignKey("CarInnovacion")]
        public int CarInnovacionId { get; set; }
        public required CarInnovacion CarInnovacion { get; set; }
    }
}
