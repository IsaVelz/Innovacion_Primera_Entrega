namespace FrontendBlazor.Models
{
    public class AspectoNormativo
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Fuente { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false; // Borrado lógico
    }
}
