using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class ProgramaPE
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("PracticaEstrategia")]
        public int PracticaEstrategiaId { get; set; }
        public required PracticaEstrategia PracticaEstrategia { get; set; }
    }
}
