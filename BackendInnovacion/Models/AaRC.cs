using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class AaRc
    {
        [Key, Column(Order = 0)]
        [ForeignKey("ActivAcademica")]
        public int ActivAcademicaId { get; set; }
        public required ActivAcademica ActivAcademica { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("RegistroCalificado")]
        public int RegistroCalificadoId { get; set; }
        public required RegistroCalificado RegistroCalificado { get; set; }

        [MaxLength(45)]
        public required string Componente { get; set; }

        [MaxLength(45)]
        public required string Semestre { get; set; }
    }
}
