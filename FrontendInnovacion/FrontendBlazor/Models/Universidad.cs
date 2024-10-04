using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//se utiliza para representar universidades dentro de la aplicación cliente, 
//y es clave para manejar los datos que vienen de la API o que se envían a ella.
namespace FrontendBlazor.Models
{
    public class Universidad
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required string Ciudad { get; set; }
        public bool IsDeleted { get; set; }
    }
}