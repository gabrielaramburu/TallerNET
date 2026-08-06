using System.Collections.Generic;
using System.Linq;
using ApiUniversidad.Modelos;

namespace ApiUniversidad.Servicios;

public class ServicioUniversidad
{
    private readonly List<Materia> _materias;
    private readonly List<Profesor> _profesores;
    private readonly Dictionary<int, List<HorarioApoyo>> _horariosApoyo;

    public ServicioUniversidad()
    {
        // 1. Instanciamos las materias completas
        var prog101 = new Materia 
        { 
            Codigo = "PROG101", 
            Nombre = "Programación", 
            Examen = new InfoExamen { FechaProximoExamen = "15 de Septiembre de 2026", Temas = new[] { "Variables", "Ciclos", "Funciones", "POO Básica" } }
        };
        var bdd202 = new Materia 
        { 
            Codigo = "BDD202", 
            Nombre = "Base de Datos", 
            Examen = new InfoExamen { FechaProximoExamen = "22 de Septiembre de 2026", Temas = new[] { "Modelo Relacional", "SQL", "Normalización" } }
        };
        var mat303 = new Materia 
        { 
            Codigo = "MAT303", 
            Nombre = "Matemáticas Discretas", 
            Examen = new InfoExamen { FechaProximoExamen = "10 de Octubre de 2026", Temas = new[] { "Lógica Proposicional", "Teoría de Conjuntos", "Grafos" } }
        };

        _materias = new List<Materia> { prog101, bdd202, mat303 };

        // 2. Asociamos las materias a los profesores usando referencias a objetos reales
        var juanPerez = new Profesor { Id = 1, Nombre = "Juan Pérez", MateriasQueDicta = new List<Materia> { prog101 } };
        var anaGomez = new Profesor { Id = 2, Nombre = "Ana Gómez", MateriasQueDicta = new List<Materia> { bdd202, mat303 } };

        _profesores = new List<Profesor> { juanPerez, anaGomez };

        // 3. Asociamos los horarios referenciando también a las materias
        _horariosApoyo = new Dictionary<int, List<HorarioApoyo>>
        {
            { 
                juanPerez.Id, 
                new List<HorarioApoyo> { new HorarioApoyo { Materia = prog101, DiasDisponibles = new[] { "Lunes", "Miércoles" } } } 
            },
            { 
                anaGomez.Id, 
                new List<HorarioApoyo> { 
                    new HorarioApoyo { Materia = bdd202, DiasDisponibles = new[] { "Martes", "Jueves" } },
                    new HorarioApoyo { Materia = mat303, DiasDisponibles = new[] { "Viernes" } }
                } 
            }
        };
    }

    public Materia? ObtenerMateria(string codigo)
    {
        return _materias.FirstOrDefault(m => m.Codigo.Equals(codigo, System.StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Profesor> ObtenerProfesores()
    {
        return _profesores;
    }

    public List<HorarioApoyo> ObtenerHorariosApoyo(int idProfesor)
    {
        if (_horariosApoyo.TryGetValue(idProfesor, out var horarios))
        {
            return horarios;
        }
        return new List<HorarioApoyo>();
    }
}
