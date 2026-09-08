using _08_demo_mvc_seguridad_OpenID.Models;
using System;
using System.Collections.Concurrent;

namespace _08_demo_mvc_seguridad_OpenID.Repositorios;

/// <summary>
/// Implementación en memoria del repositorio de cursos, docentes, estudiantes e inscripciones.
/// Mantiene estructuras de datos en memoria aplicando principios de programación orientada a objetos.
/// </summary>
public class CursoRepositorioEnMemoria : ICursoRepositorio
{
    private readonly ConcurrentDictionary<int, Docente> _docentes = new();
    private readonly ConcurrentDictionary<int, Curso> _cursos = new();
    private readonly ConcurrentDictionary<string, Estudiante> _estudiantes = new(); // Clave: UsuarioSub
    private readonly List<Inscripcion> _inscripciones = new();
    private readonly object _lockInscripciones = new();
    private int _proximoIdInscripcion = 1;
    private int _proximoIdEstudiante = 1;
    private int _proximoIdDocente = 10;

    public CursoRepositorioEnMemoria()
    {
        CargarDatosSemilla();
    }

    private void CargarDatosSemilla()
    {
        // 1. Docentes semilla (incluyendo docente1@demo.com para pruebas directas con Auth0)
        var docenteGabriel = new Docente { Id = 1, NombreCompleto = "Prof. Docente 1", Especialidad = "Seguridad Web y OpenID", Email = "docente1@demo.com" };
        var docenteMartin = new Docente { Id = 2, NombreCompleto = "Prof. Martín Silva", Especialidad = "C# y .NET Backend", Email = "martin.silva@demo.edu" };
        var docenteValeria = new Docente { Id = 3, NombreCompleto = "Dra. Valeria Gómez", Especialidad = "Sistemas Distribuidos", Email = "valeria.gomez@demo.edu" };
        var docenteRoberto = new Docente { Id = 4, NombreCompleto = "Ing. Roberto Fernández", Especialidad = "Bases de Datos y Persistencia", Email = "roberto.fernandez@demo.edu" };

        _docentes.TryAdd(docenteGabriel.Id, docenteGabriel);
        _docentes.TryAdd(docenteMartin.Id, docenteMartin);
        _docentes.TryAdd(docenteValeria.Id, docenteValeria);
        _docentes.TryAdd(docenteRoberto.Id, docenteRoberto);

        // 2. Cursos semilla con asociaciones POO y Enum NivelCurso
        var cursosIniciales = new List<Curso>
        {
            new()
            {
                Id = 1,
                Titulo = "Introducción a C# y Desarrollo Backend",
                DescripcionCorta = "Aprende los fundamentos del lenguaje C# moderno y la construcción de aplicaciones backend.",
                DescripcionCompleta = "Este curso cubre sintaxis básica, colecciones genéricas, LINQ, programación asíncrona (async/await) y diseño de software orientado a objetos.",
                Nivel = NivelCurso.Principiante,
                HorasEstimadas = 20,
                Docente = docenteMartin,
                Categoria = "Programación",
                IconoBootstrap = "bi-filetype-cs"
            },
            new()
            {
                Id = 2,
                Titulo = "Desarrollo Web con ASP.NET Core MVC",
                DescripcionCorta = "Construye aplicaciones web robustas siguiendo el patrón Modelo-Vista-Controlador.",
                DescripcionCompleta = "Aprenderás sobre el pipeline HTTP, inyección de dependencias, routing, model binding, validaciones y diseño con vistas parciales.",
                Nivel = NivelCurso.Intermedio,
                HorasEstimadas = 35,
                Docente = docenteGabriel,
                Categoria = "Web",
                IconoBootstrap = "bi-window-stack"
            },
            new()
            {
                Id = 3,
                Titulo = "Seguridad en Aplicaciones Web: Estándar OpenID Connect",
                DescripcionCorta = "Aprende a delegar la autenticación a proveedores de identidad (IdP) externos.",
                DescripcionCompleta = "Domina los flujos de autorización modernos, tokens JWT, ID Tokens, Claims, scopes y cómo proteger controladores y datos según roles.",
                Nivel = NivelCurso.Avanzado,
                HorasEstimadas = 25,
                Docente = docenteGabriel,
                Categoria = "Seguridad",
                IconoBootstrap = "bi-shield-lock-fill"
            },
            new()
            {
                Id = 4,
                Titulo = "Arquitectura de Software y Patrones de Diseño",
                DescripcionCorta = "Principios SOLID, Clean Architecture y buenas prácticas de ingeniería.",
                DescripcionCompleta = "Desacoplamiento de componentes, patrón Repository, servicios de dominio y preparación para microservicios.",
                Nivel = NivelCurso.Avanzado,
                HorasEstimadas = 40,
                Docente = docenteValeria,
                Categoria = "Arquitectura",
                IconoBootstrap = "bi-diagram-3-fill"
            },
            new()
            {
                Id = 5,
                Titulo = "Acceso a Datos y Persistencia de Objetos",
                DescripcionCorta = "Técnicas de consulta, concurrencia y mapeo de objetos.",
                DescripcionCompleta = "Manejo de colecciones concurrentes, conceptos de concurrencia segura, consultas LINQ optimizadas y comparación con ORMs.",
                Nivel = NivelCurso.Intermedio,
                HorasEstimadas = 30,
                Docente = docenteRoberto,
                Categoria = "Datos",
                IconoBootstrap = "bi-database-fill-gear"
            }
        };

        foreach (var curso in cursosIniciales)
        {
            _cursos.TryAdd(curso.Id, curso);
        }
    }

    public IEnumerable<Curso> ObtenerTodos()
    {
        return _cursos.Values.OrderBy(c => c.Id);
    }

    public Curso? ObtenerPorId(int id)
    {
        _cursos.TryGetValue(id, out var curso);
        return curso;
    }

    public bool Agregar(Curso curso)
    {
        if (curso.Id == 0)
        {
            curso.Id = _cursos.Keys.DefaultIfEmpty(0).Max() + 1;
        }
        return _cursos.TryAdd(curso.Id, curso);
    }

    public IEnumerable<Docente> ObtenerDocentes()
    {
        return _docentes.Values.OrderBy(d => d.Id);
    }

    public Docente? ObtenerDocentePorId(int id)
    {
        _docentes.TryGetValue(id, out var docente);
        return docente;
    }

    public Docente ObtenerOCrearDocente(string? usuarioSub, string? email, string? nombre)
    {
        // Buscar por email o sub
        var docenteExistente = _docentes.Values.FirstOrDefault(d => 
            (!string.IsNullOrEmpty(email) && string.Equals(d.Email, email, StringComparison.OrdinalIgnoreCase)) ||
            (!string.IsNullOrEmpty(usuarioSub) && string.Equals(d.UsuarioSub, usuarioSub, StringComparison.OrdinalIgnoreCase)));

        if (docenteExistente != null)
        {
            if (string.IsNullOrEmpty(docenteExistente.UsuarioSub) && !string.IsNullOrEmpty(usuarioSub))
            {
                docenteExistente.UsuarioSub = usuarioSub;
            }
            return docenteExistente;
        }

        var nuevoDocente = new Docente
        {
            Id = _proximoIdDocente++,
            NombreCompleto = !string.IsNullOrWhiteSpace(nombre) ? nombre : (email ?? "Docente"),
            Email = email,
            UsuarioSub = usuarioSub,
            Especialidad = "Docente Titular"
        };

        _docentes.TryAdd(nuevoDocente.Id, nuevoDocente);
        return nuevoDocente;
    }

    public IEnumerable<Curso> ObtenerCursosPorDocente(string? email, string? usuarioSub)
    {
        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(usuarioSub))
            return Enumerable.Empty<Curso>();

        return _cursos.Values.Where(c =>
            (c.Docente != null && !string.IsNullOrEmpty(email) && string.Equals(c.Docente.Email, email, StringComparison.OrdinalIgnoreCase)) ||
            (c.Docente != null && !string.IsNullOrEmpty(usuarioSub) && string.Equals(c.Docente.UsuarioSub, usuarioSub, StringComparison.OrdinalIgnoreCase))
        ).OrderBy(c => c.Id).ToList();
    }

    public Estudiante? ObtenerEstudiantePorSub(string usuarioSub)
    {
        if (string.IsNullOrWhiteSpace(usuarioSub)) return null;
        _estudiantes.TryGetValue(usuarioSub, out var estudiante);
        return estudiante;
    }

    public IEnumerable<Curso> ObtenerCursosInscritos(string usuarioSub)
    {
        if (string.IsNullOrWhiteSpace(usuarioSub))
            return Enumerable.Empty<Curso>();

        lock (_lockInscripciones)
        {
            return _inscripciones
                .Where(i => i.Estudiante.UsuarioSub == usuarioSub)
                .Select(i => i.Curso)
                .OrderBy(c => c.Id)
                .ToList();
        }
    }

    public bool EstaInscrito(int cursoId, string usuarioSub)
    {
        if (string.IsNullOrWhiteSpace(usuarioSub))
            return false;

        lock (_lockInscripciones)
        {
            return _inscripciones.Any(i => i.Curso.Id == cursoId && i.Estudiante.UsuarioSub == usuarioSub);
        }
    }

    public bool InscribirEstudiante(int cursoId, string usuarioSub, string usuarioEmail, string nombreEstudiante)
    {
        if (string.IsNullOrWhiteSpace(usuarioSub) || !_cursos.TryGetValue(cursoId, out var curso))
            return false;

        //TODO: es muy mala práctica realizar exclusión mutua (lock)
        //en un servidor web, ya que puede generar bloqueos y afectar la escalabilidad. 
        // de todas manera tener un repositorio en memoria tampoco es práctico y solo se usa para prueba.


        lock (_lockInscripciones)
        {
            //si el estudiante no existe, lo creamos y lo agregamos al diccionario de estudiantes 
            // Estrageia 2: creación por demanda
       

            //TODO: observar como esta funcionalidad de agregar estudiante debería de estar
            //encapsulada en un método aparte que se llame por ejemplo "ObtenerOCrearEstudiante"
            //Este método realiza más de lo que le nombre sugiere, ya que no solo Inscribe sino que también crea un estudiante si no existe.
            //Esto es un error de diseño, ya que el nombre del método no refleja su verdadera funcionalidad. 
            if (!_estudiantes.TryGetValue(usuarioSub, out var estudiante))
            {
                estudiante = new Estudiante
                {
                    Id = _proximoIdEstudiante++,
                    UsuarioSub = usuarioSub,
                    Email = usuarioEmail,
                    NombreCompleto = string.IsNullOrWhiteSpace(nombreEstudiante) ? "Estudiante" : nombreEstudiante
                };
                _estudiantes.TryAdd(usuarioSub, estudiante);
            }

            if (_inscripciones.Any(i => i.Curso.Id == cursoId && i.Estudiante.UsuarioSub == usuarioSub))
            {
                return true;
            }

            _inscripciones.Add(new Inscripcion
            {
                Id = _proximoIdInscripcion++,
                Curso = curso,
                Estudiante = estudiante,
                FechaInscripcion = DateTime.UtcNow
            });

            return true;
        }
    }
}
