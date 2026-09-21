using Microsoft.AspNetCore.Mvc;

namespace DemoSesion.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
