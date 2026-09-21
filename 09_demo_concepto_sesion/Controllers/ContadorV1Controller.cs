using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoSesion.Models;

namespace DemoSesion.Controllers;

public class ContadorV1Controller : Controller
{
    private readonly ILogger<ContadorV1Controller> _logger;
    // Por defecto cada controlador es de tipo transient, 
    //lo que significa que se crea una nueva instancia del controlador para cada solicitud HTTP. 
    //Por lo tanto, cada vez que se llama a una acción en este controlador, 
    //se crea una nueva instancia de ContadorV1Controller y, por ende, una nueva instancia de Contador.
    private Contador _contador;

    public ContadorV1Controller(ILogger<ContadorV1Controller> logger)
    {
        _logger = logger;
        _contador = new Contador();
        _logger.LogInformation("ContadorV1Controller instanciado. Nueva instancia de Contador creada con valor: {Valor}", _contador.Valor);
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Acción [GET] Index invocada. Valor del contador: {Valor}", _contador.Valor);
        return View(_contador);
    }

    [HttpPost]
    public IActionResult Incrementar()
    {
        _contador.Incrementar();
        _logger.LogInformation("Acción [POST] Incrementar invocada. Contador incrementado a valor: {Valor}", _contador.Valor);
        return View("Index", _contador);
    }
}
