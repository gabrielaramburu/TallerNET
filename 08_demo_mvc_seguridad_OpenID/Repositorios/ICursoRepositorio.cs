using _08_demo_mvc_seguridad_OpenID.Models;

namespace _08_demo_mvc_seguridad_OpenID.Repositorios;

/// <summary>
/// Contrato del repositorio para la gestión de cursos, docentes, estudiantes e inscripciones.
/// </summary>
public interface ICursoRepositorio
{
    IEnumerable<Curso> ObtenerTodos();
    Curso? ObtenerPorId(int id);
    bool Agregar(Curso curso);
    
    // Gestión y filtrado de Cursos para Docentes
    IEnumerable<Docente> ObtenerDocentes();
    Docente? ObtenerDocentePorId(int id);
    Docente ObtenerOCrearDocente(string? usuarioSub, string? email, string? nombre);
    IEnumerable<Curso> ObtenerCursosPorDocente(string? email, string? usuarioSub);

    // Gestión de Estudiantes e Inscripciones
    IEnumerable<Curso> ObtenerCursosInscritos(string usuarioSub);
    bool EstaInscrito(int cursoId, string usuarioSub);
    bool InscribirEstudiante(int cursoId, string usuarioSub, string usuarioEmail, string nombreEstudiante);
    Estudiante? ObtenerEstudiantePorSub(string usuarioSub);
}
