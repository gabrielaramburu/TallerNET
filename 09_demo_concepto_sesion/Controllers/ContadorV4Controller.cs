using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoSesion.Controllers;

public class ContadorV4Controller : Controller
{
    private readonly ILogger<ContadorV4Controller> _logger;

    public ContadorV4Controller(ILogger<ContadorV4Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("ContadorV4 [GET] Index. El servidor entrega la vista y el script; el estado reside en la memoria del navegador.");
        return View();
    }
}
