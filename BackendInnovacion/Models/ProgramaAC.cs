using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class ProgramaAC
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("AreaConocimiento")]
        public int AreaConocimientoId { get; set; }
        public required AreaConocimiento AreaConocimiento { get; set; }
    }
}
