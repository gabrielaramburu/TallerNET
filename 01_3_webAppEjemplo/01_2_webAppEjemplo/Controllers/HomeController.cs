using _01_2_webAppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace _01_2_webAppEjemplo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Obervar en Programa.cs que el controlador por defecto es Home y el action por defecto es Index
        //es Index, por lo tanto si ingreso a la url base del sitio entro a este lugar
        public IActionResult Index()
        {
            //La vista que invoco es Views/Home/Index.cshtml, 
            //ya que el controlador se llama Home y el action Index 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // El formato de enrrutamiento se define en el archivo Program.cs
        // http://localhost:5262/Home/Welcome?name=Pepe&value=8
        // Observar que los parámetros se obtienen de la url
        // Este ejemplo retornar un string simple
        public string Welcome(string name, int value)
        {
            return HtmlEncoder.Default.Encode($"Hola {name}, el valor es {value}");
        }

        // http://localhost:5262/Home/Welcome2?name=Pepe&value=8
        // Este ejemplo retorna una view cargada con datos
        public IActionResult Welcome2(string name, int value)
        {
            ViewData["Name"] = "Hola " + name;
            ViewData["Value"] = value;

            // cunado invoco a una vista que no pertence al controlador, tengo que indicar el camino completo
            return View("/Views/Vehiculo/ViewVehiculo.cshtml");
        }
    }
}
