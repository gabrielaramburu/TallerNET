using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiUniversidad.Servicios;

namespace ApiUniversidad.Controladores;

[ApiController]
[Route("api")]
public class UniversidadController : ControllerBase
{
    private readonly ServicioUniversidad _servicio;
    private readonly ILogger<UniversidadController> _logger;

    // Inyectamos el servicio y el logger en el constructor
    public UniversidadController(ServicioUniversidad servicio, ILogger<UniversidadController> logger)
    {
        _servicio = servicio;
        _logger = logger;
    }

    [HttpGet("materias/{codigo}/examen")]
    public IActionResult ObtenerInfoExamen(string codigo)
    {
        _logger.LogInformation("Solicitud recibida para obtener información del examen de la materia '{Codigo}'", codigo);
        var materia = _servicio.ObtenerMateria(codigo);
        if (materia == null)
        {
            _logger.LogWarning("Materia '{Codigo}' no encontrada", codigo);
            return NotFound(new { Mensaje = $"No se encontró la materia con código '{codigo}'" });
        }
        
        return Ok(materia);
    }

    [HttpGet("profesores")]
    public IActionResult ObtenerProfesores()
    {
        _logger.LogInformation("Solicitud recibida para obtener la lista completa de profesores");
        var profesores = _servicio.ObtenerProfesores();
        _logger.LogInformation("Retornando información de profesores");
        return Ok(profesores);
    }

    [HttpGet("profesores/{id:int}/horarios")]
    public IActionResult ObtenerHorariosApoyo(int id)
    {
        _logger.LogInformation("Solicitud recibida para obtener horarios del profesor con ID {Id}", id);
        var horarios = _servicio.ObtenerHorariosApoyo(id);
        if (horarios.Count == 0)
        {
            _logger.LogWarning("No se encontraron horarios para el profesor ID {Id}", id);
            return NotFound(new { Mensaje = $"No se encontraron horarios para el profesor con ID '{id}'" });
        }
        _logger.LogInformation("Retornando horarios para el profesor ID {Id}", id);
        return Ok(horarios);
    }
}
