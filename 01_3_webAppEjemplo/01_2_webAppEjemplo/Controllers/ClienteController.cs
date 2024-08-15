using Microsoft.AspNetCore.Mvc;

namespace _01_3_webAppEjemplo.Controllers
{
    [Route("Cliente")]
    public class ClienteController : Controller
    {
 
        //Observar como desde la página acceso al controlador por el nombre
        //del action MostrarClientes
        public IActionResult MostrarClientes()
        {
            return View("TiposClientes");
        }

        [Route("MostrarPersonas")]
        public IActionResult MostrarPersonas()
        {
            return View("_Personas");
        }

        [Route("MostrarEmpresas")]
        public IActionResult MostrarEmpresas()
        {
            return View("_Empresas");
        }
    }
}
