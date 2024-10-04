namespace FrontendBlazor.Models
{
    public class PracticaEstrategia
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false; // Borrado lógico
    }
}
