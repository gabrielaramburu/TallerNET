namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa a un estudiante en el dominio de la aplicación.
/// Mantiene la vinculación con el identificador único federado 'sub' de OpenID Connect.
/// </summary>
public class Estudiante
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UsuarioSub { get; set; } = string.Empty; // Identificador universal emitido por OpenID
}
