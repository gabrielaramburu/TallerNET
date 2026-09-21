using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoSesion.Services;

namespace DemoSesion.Controllers;

public class ContadorV2Controller : Controller
{
    //Este controlador utiliza un servicio de contador que se inyecta a través del constructor.
    //El servicio de contador es de tipo singleton, lo que significa que se comparte entre todas las instancias del controlador y todas las solicitudes HTTP.
    private readonly IServicioContador _servicioContador;
    private readonly ILogger<ContadorV2Controller> _logger;

    public ContadorV2Controller(IServicioContador servicioContador, ILogger<ContadorV2Controller> logger)
    {
        _servicioContador = servicioContador;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("ContadorV2 [GET] Index. Valor actual: {Valor}", _servicioContador.Contador.Valor);
        return View(_servicioContador.Contador);
    }

    [HttpPost]
    public IActionResult Incrementar()
    {
        _servicioContador.Incrementar();
        _logger.LogInformation("ContadorV2 [POST] Incrementar. Nuevo valor: {Valor}", _servicioContador.Contador.Valor);
        return View("Index", _servicioContador.Contador);
    }
}
