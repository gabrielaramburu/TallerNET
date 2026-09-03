using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _08_demo_mvc_seguridad_OpenID.Models;

namespace _08_demo_mvc_seguridad_OpenID.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Vista estática/documental con el esquema de funcionalidades, roles y arquitectura didáctica.
    /// </summary>
    public IActionResult Readme()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
