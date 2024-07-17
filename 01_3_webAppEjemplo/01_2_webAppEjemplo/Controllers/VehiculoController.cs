using _01_3_webAppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace _01_2_webAppEjemplo.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> _logger;
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoController(ILogger<VehiculoController> logger, IVehiculoRepository repo)
        {
            _logger = logger;
            _vehiculoRepository = repo;
        }
        public IActionResult Index()
        {
            // retorno (previo renderizado) el archivo View.cshtml
            return View("ViewVehiculo");
        }

        // El formato de enrrutamiento se define en el archivo Program.cs
        // https://localhost:7144/Vehiculo/Welcome?name=Pepe&value=8
        // Observar que los parámetros se obtienen de la url
        // Este ejemplo retornar un string simple
        public string Welcome(string name, int value)
        {
            return HtmlEncoder.Default.Encode($"Hola {name}, el valor es {value}");
        }

        // https://localhost:7144/Vehiculo/Welcome2?name=Pepe&value=8
        // Este ejemplo retorna una view cargada con datos
        public IActionResult Welcome2(string name, int value)
        {
            ViewData["Name"] = "Hola " + name;
            ViewData["Value"] = value;
            return View("ViewVehiculo");
        }

        public IActionResult GetAllVehiculos()
        {
            return View("GrillaVehiculo", this._vehiculoRepository.GetVehiculos());
        }
    }
}
