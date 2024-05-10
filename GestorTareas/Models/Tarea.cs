namespace GestorTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public bool Completado { get; set; }
        
    }
}
