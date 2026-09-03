using _08_demo_mvc_seguridad_OpenID.Models;

namespace _08_demo_mvc_seguridad_OpenID.ViewModels.Cursos;

/// <summary>
/// ViewModel para representar los datos necesarios en la vista parcial de tarjeta de curso.
/// </summary>
public class TarjetaCursoViewModel
{
    public Curso Curso { get; set; } = null!;
    public bool EstaInscrito { get; set; }
    public bool EsUsuarioAutenticado { get; set; }
}
