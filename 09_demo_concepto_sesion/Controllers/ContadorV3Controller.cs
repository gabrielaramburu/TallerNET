using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoSesion.Models;
using DemoSesion.Extensions;

namespace DemoSesion.Controllers;

public class ContadorV3Controller : Controller
{
    //la session funciona como un diccionario de clave-valor,
    //donde podemos almacenar cualquier objeto serializable asociado a una clave única.
    private const string ClaveSesion = "ObjetoContador";

    private readonly ILogger<ContadorV3Controller> _logger;

    public ContadorV3Controller(ILogger<ContadorV3Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Recuperamos el objeto Contador de la sesión
        var contador = HttpContext.Session.Get<Contador>(ClaveSesion);

        if (contador == null)
        {
            //si es la primera vez que se accede, creamos un nuevo objeto Contador y lo guardamos en la sesión
            contador = new Contador();
            HttpContext.Session.Set(ClaveSesion, contador);
        }

        string idSesion = HttpContext.Session.Id;
        ViewBag.IdSesion = idSesion;

        _logger.LogInformation("ContadorV3 [GET] Index. Sesión: {IdSesion}, Objeto Contador recuperado con valor: {Valor}", idSesion, contador.Valor);

        return View(contador);
    }

    [HttpPost]
    public IActionResult Incrementar()
    {
        // Recuperamos el objeto Contador existente en la sesión (o creamos uno si no existiera)
        var contador = HttpContext.Session.Get<Contador>(ClaveSesion) ?? new Contador();

        // Mutamos el objeto llamando a su método de negocio
        contador.Incrementar();

        // Volvemos a guardar el objeto actualizado en la sesión
        HttpContext.Session.Set(ClaveSesion, contador);

        string idSesion = HttpContext.Session.Id;
        ViewBag.IdSesion = idSesion;

        _logger.LogInformation("ContadorV3 [POST] Incrementar. Sesión: {IdSesion}, Objeto Contador incrementado y guardado con valor: {Valor}", idSesion, contador.Valor);

        return View("Index", contador);
    }
}
