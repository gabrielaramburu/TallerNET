using _01_3_webAppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;

namespace _01_2_webAppEjemplo.Controllers
{
    [Route("Vehiculo")]
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> _logger;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IWebHostEnvironment _webRootPath;

        public VehiculoController(ILogger<VehiculoController> logger, 
            IVehiculoRepository repo,
            IWebHostEnvironment path)
        {
            _logger = logger;
            _vehiculoRepository = repo;
            _webRootPath = path;
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


        [Route("EjemploDondeDevuelvoHtml")]
        public IActionResult EjemploDondeDevuelvoHtml()
        {
            //observar que los archivos estáticos van en la carpeta wwwroot
            string htmlFilePath = Path.Combine(_webRootPath.WebRootPath, "ejemplo.html");
            _logger.LogInformation("Camino: " + htmlFilePath);
            var fileBytes = System.IO.File.ReadAllBytes(htmlFilePath);

            FileContentResult file = File(fileBytes, "text/html");
            return file;
        }


        [Route("EjemploAcoplado")]
        public IActionResult EjemploAcoplado()
        {
            //si bien este código se podría sacar a una clase Helper
            //la manera en que generamos la vista no es mantenible
            //ni práctica de usar
            _logger.LogInformation("Ejecutando ejemplo codigo acoplado");
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>Lista de Vehículos</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; }");
            sb.AppendLine("table, th, td { border: 1px solid black; }");
            sb.AppendLine("th, td { padding: 8px; text-align: left; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h1>Lista de Vehículos</h1>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>Marca</th>");
            sb.AppendLine("<th>Modelo</th>");
            sb.AppendLine("<th>Año</th>");
            sb.AppendLine("<th>Color</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (var vehiculo in this._vehiculoRepository.GetVehiculos())
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{vehiculo.Marca}</td>");
                sb.AppendLine($"<td>{vehiculo.Modelo}</td>");
                sb.AppendLine($"<td>{vehiculo.AnioFabricacion}</td>");
                sb.AppendLine($"<td>{vehiculo.Matricula}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return Content(sb.ToString(), "text/html");
        }
    }
}
