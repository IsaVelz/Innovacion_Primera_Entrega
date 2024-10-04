using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendInnovacion.Models
{
    public class AreaConocimiento
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public required string GranArea { get; set; }

        [MaxLength(60)]
        public required string Area { get; set; }

        [MaxLength(60)]
        public required string Disciplina { get; set; }
        public bool IsDeleted { get; set; } = false; // Nuevo campo para el borrado lógico
    }
}
