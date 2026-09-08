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
    //el servicio de autenticación externa (Auth0) en este caso pero recordar que estamos frente a un
    //estandar por lo tanto podría ser otro proveedor que cumpla con OpenID, es el que lleva control
    //de los usuarios y sus roles, y el sub es un identificador único para cada usuario en ese proveedor.
}
