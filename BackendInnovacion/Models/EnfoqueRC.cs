using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class EnfoqueRC
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Enfoque")]
        public int EnfoqueId { get; set; }
        public required Enfoque Enfoque { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("RegistroCalificado")]
        public int RegistroCalificadoId { get; set; }
        public required RegistroCalificado RegistroCalificado { get; set; }
    }
}
