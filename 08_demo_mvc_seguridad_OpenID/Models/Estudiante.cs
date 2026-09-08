namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa a un estudiante en el dominio de la aplicación.
/// Mantiene la vinculación con el identificador único federado 'sub' de OpenID Connect.
/// </summary>
/// 
//TODO: observar como el LLM tampoco reconoce que existe una reláción entre Estudiante y Docente, y que debería de existir una relación entre Estudiante y Curso
//y que debería de crear (mediant generalización) una clase padre Usuario
//que contenga los atributos comunes entre Estudiante y Docente, y que Estudiante y Docente hereden de Usuario.
public class Estudiante
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UsuarioSub { get; set; } = string.Empty; // Identificador universal emitido por OpenID
}
