namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa un curso en la plataforma educativa.
/// </summary>
public class Curso
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string DescripcionCorta { get; set; } = string.Empty;
    public string DescripcionCompleta { get; set; } = string.Empty;
    
    // Tipado fuerte con Enum
    public NivelCurso Nivel { get; set; } = NivelCurso.Principiante;
    
    public int HorasEstimadas { get; set; }
    
    // Asociación pura de POO con la entidad Docente
    public Docente Docente { get; set; } = null!;
    
    public string Categoria { get; set; } = "Desarrollo";
    public string IconoBootstrap { get; set; } = "bi-journal-code";
}
