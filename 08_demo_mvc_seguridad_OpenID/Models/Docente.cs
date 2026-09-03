namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa a un docente dentro del modelo de dominio.
/// </summary>
public class Docente
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public string? Email { get; set; }
    public string? UsuarioSub { get; set; } // Identificador federado 'sub' de OpenID
}
