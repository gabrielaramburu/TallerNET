using System.ComponentModel.DataAnnotations;
using _08_demo_mvc_seguridad_OpenID.Models;

namespace _08_demo_mvc_seguridad_OpenID.ViewModels.Cursos;

/// <summary>
/// ViewModel para la creación de un nuevo curso por parte del Docente autenticado.
/// El docente se asocia automáticamente a partir de la identidad de OpenID Connect.
/// </summary>
public class CrearCursoViewModel
{
    [Required(ErrorMessage = "El título del curso es obligatorio.")]
    [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres.")]
    [Display(Name = "Título del Curso")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [StringLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres.")]
    [Display(Name = "Categoría")]
    public string Categoria { get; set; } = "Desarrollo";

    [Required(ErrorMessage = "La carga horaria es obligatoria.")]
    [Range(1, 300, ErrorMessage = "La carga horaria debe estar entre 1 y 300 horas.")]
    [Display(Name = "Carga Horaria (Horas)")]
    public int HorasEstimadas { get; set; } = 20;

    [Required(ErrorMessage = "Debe seleccionar un nivel de dificultad.")]
    [Display(Name = "Nivel de Dificultad")]
    public NivelCurso Nivel { get; set; } = NivelCurso.Principiante;

    [Required(ErrorMessage = "La descripción corta es obligatoria.")]
    [StringLength(200, ErrorMessage = "La descripción corta no puede superar los 200 caracteres.")]
    [Display(Name = "Descripción Breve")]
    public string DescripcionCorta { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción completa es obligatoria.")]
    [Display(Name = "Programa / Descripción Completa")]
    public string DescripcionCompleta { get; set; } = string.Empty;
}
