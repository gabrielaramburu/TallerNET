using _01_3_webAppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace _01_2_webAppEjemplo.Controllers
{
    [Route("Vehiculo")]
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> _logger;
        private readonly IVehiculoRepository _vehiculoRepository;

    
        public VehiculoController(ILogger<VehiculoController> logger, IVehiculoRepository repo)
        {
            _logger = logger;
            _vehiculoRepository = repo;
        }
      
        // https://localhost:7144/Vehiculo/GetAllVehiculos
        [Route("GetAllVehiculos")]
        public IActionResult GetAllVehiculos()
        {
            // observar que explicitamente indico el nombre de la vista que quiero renderizar
            return View("GrillaVehiculo", this._vehiculoRepository.GetVehiculos());
        }

        // Este action se llama al realizar click desde el link Editar
        [HttpGet]
        [Route("Ver/{matricula}")]
        public IActionResult Ver(string matricula)
        {
            _logger.LogInformation($"Estoy en action Ver, matricula: {matricula}" );
           

            if (matricula == null)
            {
                return NotFound("Debe especificar matrícula");
            }

            Vehiculo vehiculo;
          
            vehiculo = this._vehiculoRepository.Get(matricula);
           
            
            if (vehiculo == null)
            {
                return NotFound($"Matrícula no encontrada: {matricula}");
            }
            // observar que no indico el nombre de la vista, 
            // el framwork deduce la misma a partir del nombre del action method, en este caso Ver
            return View(vehiculo);
        }


        [HttpGet]
        [Route("Borrar/{matricula}")]
        public IActionResult Borrar(string matricula)
        {
            Vehiculo vehiculo;
            _logger.LogInformation($"Estoy en action Borrar, matricula: {matricula}");
            vehiculo = this._vehiculoRepository.Get(matricula);


            if (vehiculo == null)
            {
                return NotFound($"Matrícula no encontrada: {matricula}");
            }
           
            return View(vehiculo);
        }


        [HttpPost, ActionName("ConfirmarBorrado")]
        public IActionResult ConfirmarBorrado(string matricula)
        {
            _logger.LogInformation($"Estoy en action ConfirmarBorrardo, matricula: {matricula}");
            this._vehiculoRepository.Delete(matricula);
            return RedirectToAction("GetAllVehiculos","Vehiculo");
        }

        [HttpGet]
        [Route("Crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [Route("CrearVehiculo")]
        public IActionResult CrearVehiculo([Bind("Matricula,Modelo,Marca,AnioFabricacion")] Vehiculo vehiculo)
        {
            this._vehiculoRepository.Add(vehiculo);
            return RedirectToAction("GetAllVehiculos", "Vehiculo");
        }
        
    }
}
