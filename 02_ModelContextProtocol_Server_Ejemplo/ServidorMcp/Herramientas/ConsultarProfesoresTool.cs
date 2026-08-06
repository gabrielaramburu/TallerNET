using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

namespace ServidorMcp.Herramientas;

[McpServerToolType]
public class ConsultarProfesoresTool
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ConsultarProfesoresTool> _logger;

    public ConsultarProfesoresTool(IHttpClientFactory httpClientFactory, ILogger<ConsultarProfesoresTool> logger)
    {
        _httpClient = httpClientFactory.CreateClient("ApiUniversidad");
        _logger = logger;
    }

    [McpServerTool, Description("Obtiene la lista completa de profesores disponibles y las materias que dictan. Útil para descubrir el ID de un profesor a partir de la materia que buscas.")]
    public async Task<string> ConsultarProfesores()
    {
        _logger.LogInformation("Iniciando llamada MCP Tool: ConsultarProfesores. Destino: {BaseAddress}api/profesores", _httpClient.BaseAddress);
        try
        {
            var respuesta = await _httpClient.GetAsync("/api/profesores");
            _logger.LogInformation("Respuesta de la API recibida. StatusCode: {StatusCode}", respuesta.StatusCode);
            
            if (respuesta.IsSuccessStatusCode)
            {
                var jsonString = await respuesta.Content.ReadAsStringAsync();
                _logger.LogInformation("Datos obtenidos exitosamente. Longitud del JSON: {Length}", jsonString.Length);
                return $"Lista de profesores obtenida de la API:\n{jsonString}";
            }
            
            var errorMsg = $"Error al obtener profesores. Código HTTP: {respuesta.StatusCode}";
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
