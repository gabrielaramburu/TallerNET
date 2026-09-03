using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _08_demo_mvc_seguridad_OpenID.Models;
using _08_demo_mvc_seguridad_OpenID.Repositorios;
using _08_demo_mvc_seguridad_OpenID.ViewModels.Cursos;

namespace _08_demo_mvc_seguridad_OpenID.Controllers;

public class CursosController : Controller
{
    private readonly ICursoRepositorio _cursoRepositorio;

    public CursosController(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }

    /// <summary>
    /// Catálogo de cursos.
    /// Si el usuario es Docente, muestra exclusivamente sus cursos asignados/publicados.
    /// Si el usuario es Visitante o Estudiante, muestra el catálogo general completo.
    /// </summary>
    [AllowAnonymous]
    public IActionResult Index()
    {
        var usuarioSub = ObtenerUsuarioSubActual();
        var usuarioEmail = ObtenerUsuarioEmailActual();
        var estaAutenticado = User.Identity?.IsAuthenticated ?? false;
        var esDocente = User.IsInRole("Docente") || User.IsInRole("Admin");

        IEnumerable<Curso> cursos;

        if (esDocente)
        {
            // Para el docente, filtrar y mostrar únicamente sus propios cursos
            cursos = _cursoRepositorio.ObtenerCursosPorDocente(usuarioEmail, usuarioSub);
            ViewData["EsDocente"] = true;
        }
        else
        {
            // Catálogo general para visitantes y estudiantes
            cursos = _cursoRepositorio.ObtenerTodos();
            ViewData["EsDocente"] = false;
        }

        var viewModels = cursos.Select(c => new TarjetaCursoViewModel
        {
            Curso = c,
            EstaInscrito = !string.IsNullOrEmpty(usuarioSub) && _cursoRepositorio.EstaInscrito(c.Id, usuarioSub),
            EsUsuarioAutenticado = estaAutenticado
        }).ToList();

        return View(viewModels);
    }

    /// <summary>
    /// Detalle de un curso específico.
    /// Accesible por cualquier visitante (Rol: Visitante / Estudiante / Docente).
    /// </summary>
    [AllowAnonymous]
    public IActionResult Detalle(int id)
    {
        var curso = _cursoRepositorio.ObtenerPorId(id);
        if (curso == null)
        {
            return NotFound();
        }

        var usuarioSub = ObtenerUsuarioSubActual();
        var estaAutenticado = User.Identity?.IsAuthenticated ?? false;

        var viewModel = new TarjetaCursoViewModel
        {
            Curso = curso,
            EstaInscrito = !string.IsNullOrEmpty(usuarioSub) && _cursoRepositorio.EstaInscrito(curso.Id, usuarioSub),
            EsUsuarioAutenticado = estaAutenticado
        };

        return View(viewModel);
    }

    /// <summary>
    /// Vista de cursos en los que el estudiante autenticado está inscrito.
    /// Restringido a usuarios con rol Estudiante (o no docentes).
    /// </summary>
    [Authorize(Roles = "Estudiante")]
    public IActionResult MisCursos()
    {
        var usuarioSub = ObtenerUsuarioSubActual();
        var cursosInscritos = _cursoRepositorio.ObtenerCursosInscritos(usuarioSub!);

        var viewModels = cursosInscritos.Select(c => new TarjetaCursoViewModel
        {
            Curso = c,
            EstaInscrito = true,
            EsUsuarioAutenticado = true
        }).ToList();

        return View(viewModels);
    }

    /// <summary>
    /// Inscribe al estudiante autenticado en un curso.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Estudiante")]
    [ValidateAntiForgeryToken]
    public IActionResult Inscribirse(int cursoId)
    {
        var usuarioSub = ObtenerUsuarioSubActual();
        var usuarioEmail = ObtenerUsuarioEmailActual() ?? "correo_no_disponible";
        var nombreUsuario = ObtenerNombreUsuarioActual() ?? "Estudiante";

        _cursoRepositorio.InscribirEstudiante(cursoId, usuarioSub!, usuarioEmail, nombreUsuario);

        TempData["MensajeExito"] = "¡Te has inscrito correctamente al curso!";
        return RedirectToAction(nameof(MisCursos));
    }

    /// <summary>
    /// Muestra el formulario para crear un nuevo curso.
    /// Requiere explícitamente el rol "Docente" o "Admin".
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Docente,Admin")]
    public IActionResult Crear()
    {
        return View(new CrearCursoViewModel());
    }

    /// <summary>
    /// Procesa la creación de un nuevo curso asociándolo directamente al Docente autenticado (POO).
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Docente,Admin")]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(CrearCursoViewModel modelo)
    {
        if (!ModelState.IsValid)
        {
            return View(modelo);
        }

        var usuarioSub = ObtenerUsuarioSubActual();
        var usuarioEmail = ObtenerUsuarioEmailActual();
        var nombreUsuario = ObtenerNombreUsuarioActual();

        // Obtener o registrar al docente autenticado en memoria
        var docente = _cursoRepositorio.ObtenerOCrearDocente(usuarioSub, usuarioEmail, nombreUsuario);

        var nuevoCurso = new Curso
        {
            Titulo = modelo.Titulo,
            DescripcionCorta = modelo.DescripcionCorta,
            DescripcionCompleta = modelo.DescripcionCompleta,
            Nivel = modelo.Nivel,
            HorasEstimadas = modelo.HorasEstimadas,
            Docente = docente, // Asociación POO pura con el docente autenticado
            Categoria = modelo.Categoria,
            IconoBootstrap = "bi-journal-plus"
        };

        _cursoRepositorio.Agregar(nuevoCurso);

        TempData["MensajeExito"] = $"¡El curso '{nuevoCurso.Titulo}' ha sido publicado exitosamente en tu catálogo docente!";
        return RedirectToAction(nameof(Index));
    }

    #region Métodos Auxiliares

    private string? ObtenerUsuarioSubActual()
    {
        return User.FindFirst(ClaimTypes.NameIdentifier)?.Value
               ?? User.FindFirst("sub")?.Value;
    }

    private string? ObtenerUsuarioEmailActual()
    {
        return User.FindFirst(ClaimTypes.Email)?.Value
               ?? User.FindFirst("email")?.Value;
    }

    private string? ObtenerNombreUsuarioActual()
    {
        return User.FindFirst("name")?.Value
               ?? User.FindFirst(ClaimTypes.Name)?.Value
               ?? User.FindFirst("nickname")?.Value;
    }

    #endregion
}
