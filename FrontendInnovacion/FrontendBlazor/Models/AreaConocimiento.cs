namespace FrontendBlazor.Models
{
    public class AreaConocimiento
    {
        public int Id { get; set; }

        public string GranArea { get; set; } = string.Empty;

        public string Area { get; set; } = string.Empty;

        public string Disciplina { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false; // Borrado lógico
    }
}
