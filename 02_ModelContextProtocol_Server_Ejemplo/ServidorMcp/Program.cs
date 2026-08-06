using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using Microsoft.Extensions.Logging;

// 1. Inicializar el constructor de la aplicación
var builder = Host.CreateApplicationBuilder(args);

// Limpiar los logs por defecto para que la consola (stdout) quede limpia sólo para JSON-RPC (MCP)
builder.Logging.ClearProviders();

// 2. Configurar HTTP Client para consumir la API de la Universidad
// Leemos la URL del archivo de configuración (appsettings.json)
string apiUrl = builder.Configuration["ApiUniversidadUrl"] ?? "http://localhost:5220/";
builder.Services.AddHttpClient("ApiUniversidad", client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

// 3. Configurar el Servidor MCP
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport() // Usamos Stdio para la comunicación local (ej. Claude Desktop)
    .WithToolsFromAssembly();   // Registra automáticamente los métodos marcados con [McpServerTool]

// 4. Construir y ejecutar el servidor
var host = builder.Build();
await host.RunAsync();
