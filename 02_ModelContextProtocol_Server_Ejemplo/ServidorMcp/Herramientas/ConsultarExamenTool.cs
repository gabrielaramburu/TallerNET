using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using ModelContextProtocol.Server;

namespace ServidorMcp.Herramientas;

// 1. Etiquetamos la clase para que el servidor MCP la descubra y lea sus herramientas
[McpServerToolType]
public class ConsultarExamenTool
{
    private readonly HttpClient _httpClient;

    // 2. Inyectamos el HttpClient (configurado previamente en Program.cs)
    public ConsultarExamenTool(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiUniversidad");
    }

    // 3. Definimos el método como una Herramienta MCP (Tool) y le damos una descripción clara.
    // Esta descripción es vital: la IA la lee para saber "cuándo" y "para qué" usar esta herramienta.
    [McpServerTool, Description("Obtiene la fecha del próximo examen y los temas a evaluar para una materia específica de la universidad.")]
    public async Task<string> ConsultarInformacionExamen(
        [Description("El código de la materia (ej: 'PROG101', 'BDD202', 'MAT303')")] string codigoMateria)
    {
        try
        {
            // Hacemos la consulta GET a nuestra API REST
            var respuesta = await _httpClient.GetAsync($"/api/materias/{codigoMateria}/examen");
            
            if (respuesta.IsSuccessStatusCode)
            {
                // Le pasamos el JSON en texto crudo a la IA. Ella sabrá interpretarlo
                // y armar una respuesta en lenguaje natural para el estudiante.
                var jsonString = await respuesta.Content.ReadAsStringAsync();
                return $"Datos obtenidos con éxito de la API:\n{jsonString}";
            }
            else if (respuesta.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return $"No se encontró información para la materia '{codigoMateria}'. Pide al usuario que verifique el código.";
            }
            else
            {
                return $"Error de la API. Código HTTP: {respuesta.StatusCode}";
            }
        }
        catch (Exception ex)
        {
            return $"Error de conexión con la API de la Universidad: {ex.Message}";
        }
    }
}
