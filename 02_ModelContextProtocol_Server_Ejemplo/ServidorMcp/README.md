# Servidor MCP Universitario

Este proyecto implementa el **Model Context Protocol (MCP)** en .NET 10. Su propósito es actuar como puente, exponiendo herramientas (`Tools`) a agentes de Inteligencia Artificial para que puedan consultar datos de la `ApiUniversidad` e integrarlos a sus flujos de razonamiento.

## Cómo funciona

La aplicación expone sus herramientas a través del transporte de Entrada/Salida Estándar (`Stdio`). Esto significa que los clientes de IA lanzan el proceso de esta aplicación internamente para comunicarse con ella mediante JSON-RPC. 

**Importante:** La `ApiUniversidad` debe estar ejecutándose para que las consultas tengan éxito.

## Depurar con MCP Inspector

El **MCP Inspector** es una herramienta web oficial provista por el equipo de Model Context Protocol para probar el Servidor MCP sin necesidad de un cliente IA complejo.

Para lanzar este proyecto utilizando el Inspector, abre la terminal y utiliza `npx` (requiere Node.js instalado):

```bash
npx @modelcontextprotocol/inspector dotnet run --project /home/gabriel/workspace/TallerNET/02_ModelContextProtocol_Server_Ejemplo/ServidorMcp/ServidorMcp.csproj
```

Esto abrirá un entorno web en tu navegador donde podrás ver y ejecutar manualmente `ConsultarProfesores` y `ConsultarHorariosApoyo`.

## Configuración para Antigravity / Otros Clientes IA

Para que un cliente de IA (como **Antigravity** o Claude Desktop) reconozca y utilice este servidor MCP, debes agregar el siguiente bloque JSON a su archivo de configuración:

```json
{
  "mcpServers": {
    "UniversidadLocal": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "/home/gabriel/workspace/TallerNET/02_ModelContextProtocol_Server_Ejemplo/ServidorMcp/ServidorMcp.csproj"
      ]
    }
  }
}

Para el caso de Antigravity CLI, el archivo de configuración esta en la carpeta ~/.gemini/config/mcp_config.json (linux)
Dependiendo del host, esto también se puede configurar desde la interface gráfica.


*Una vez configurado y reiniciado el cliente de IA, ¡podrás preguntarle por horarios de exámenes o tutorías y verás cómo usa las herramientas de forma autónoma!*
