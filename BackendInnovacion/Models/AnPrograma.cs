using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class AnPrograma
    {
        [Key, Column(Order = 0)]
        [ForeignKey("AspectoNormativo")]
        public int AspectoNormativoId { get; set; }
        public required AspectoNormativo AspectoNormativo { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Programa")]
        public int ProgramaId { get; set; }
        public required Programa Programa { get; set; }
    }
}
