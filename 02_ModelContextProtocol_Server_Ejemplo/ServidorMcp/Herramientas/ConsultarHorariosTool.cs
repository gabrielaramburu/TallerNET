using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

namespace ServidorMcp.Herramientas;

[McpServerToolType]
public class ConsultarHorariosTool
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ConsultarHorariosTool> _logger;

    public ConsultarHorariosTool(IHttpClientFactory httpClientFactory, ILogger<ConsultarHorariosTool> logger)
    {
        _httpClient = httpClientFactory.CreateClient("ApiUniversidad");
        _logger = logger;
    }

    [McpServerTool, Description("Obtiene los días de clases de apoyo disponibles para un profesor específico usando su ID numérico.")]
    public async Task<string> ConsultarHorariosApoyo(
        [Description("El ID numérico del profesor (ej: 1, 2)")] int idProfesor)
    {
        _logger.LogInformation("Iniciando llamada MCP Tool: ConsultarHorariosApoyo para ID={IdProfesor}", idProfesor);
        try
        {
            var respuesta = await _httpClient.GetAsync($"/api/profesores/{idProfesor}/horarios");
            _logger.LogInformation("Respuesta de la API recibida. StatusCode: {StatusCode}", respuesta.StatusCode);
            
            if (respuesta.IsSuccessStatusCode)
            {
                var jsonString = await respuesta.Content.ReadAsStringAsync();
                _logger.LogInformation("Datos obtenidos exitosamente. Longitud del JSON: {Length}", jsonString.Length);
                return $"Horarios de apoyo encontrados para el profesor {idProfesor}:\n{jsonString}";
            }
            else if (respuesta.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogWarning("La API retornó NotFound para el profesor ID={IdProfesor}", idProfesor);
                return $"No se encontraron horarios para el profesor con ID '{idProfesor}'.";
            }
            
            var errorMsg = $"Error al consultar la API. Código HTTP: {respuesta.StatusCode}";
            _logger.LogError(errorMsg);
            return errorMsg;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción al intentar conectar con la API de la Universidad.");
            return $"Error de conexión con la API: {ex.Message}. Asegúrate que la API esté corriendo en el puerto 5000.";
        }
    }
}
