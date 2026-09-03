namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa la inscripción entre un Estudiante y un Curso.
/// Sigue las buenas prácticas de diseño de POO mediante asociaciones directas entre clases.
/// </summary>
public class Inscripcion
{
    public int Id { get; set; }
    
    // Asociación directa con la entidad Curso
    public Curso Curso { get; set; } = null!;
    
    // Asociación directa con la entidad Estudiante
    public Estudiante Estudiante { get; set; } = null!;
    
    public DateTime FechaInscripcion { get; set; } = DateTime.UtcNow;
}
