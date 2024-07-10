using _01_1_webApiEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;

namespace _01_1_webApiEjemplo.Controllers
{
    [ApiController] //Esto es un atributo que es utilizada en tiempo de ejecución
                    //para agregar comportamiento a la clase (idem to anotacion en java)    
                    //Indica que el controlador responde a peticiones web
  
    [Route("api/vehiculos")]
    public class VehiculoController : Controller
    {
        // para poder logear (observar que ademas se agrega línea en archivo Program.cs)
        private readonly ILogger<VehiculoController> _logger;

        private IList<Vehiculo> _vehiculoList;

        public VehiculoController(ILogger<VehiculoController> logger) {
            this._logger = logger; // una instancia del logger se injecta usando el constructor

            this._vehiculoList = new List<Vehiculo>();
            this._vehiculoList.Add(new Vehiculo(1, "BAA 1234", "Ford"));
            this._vehiculoList.Add(new Vehiculo(2, "BAA 5555", "Nissan"));
        }

        [HttpGet] // endpoit asociado al metodo GET
        public ActionResult<IList<Vehiculo>> GetAll()
        //ActionResult es la clase base de todos los tipos posibles de respuesta del endpoint
        //(ViewResult, PartialViewResult, ContentResult, EmptyResult, JsonResult)
        {
            _logger.LogInformation("Retorno lista de vehiculos");
            return Ok(_vehiculoList.ToList());
        }

        [HttpGet]
        [Route("{id}")] //obtendo parámetro desde la url
        public ActionResult<Vehiculo> GetById(int id)
        {
            _logger.LogInformation($"Retorno vehiculo en posicion {id}"); // formato de interpolación de cadenas
            return Ok(_vehiculoList[id]);
        }

        [HttpPost] //ejemplo de post
        public ActionResult Nuevo([FromBody]Vehiculo vehiculo) //notese el atributo FromBody
        {
            _logger.LogInformation("Nuevo vehiculo");
            this._vehiculoList.Add(vehiculo);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public ActionResult Borrar(int id)
        {
            _logger.LogInformation("Borrar vehiculo");
            this._vehiculoList.RemoveAt(id);
            return Ok();
        }
    }
}
