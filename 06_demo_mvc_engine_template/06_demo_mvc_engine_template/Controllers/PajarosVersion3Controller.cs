using _06_demo_mvc_engine_template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Text;

namespace _06_demo_mvc_engine_template.Controllers
{
   
    public class PajarosVersion3Controller : Controller
    {
        private readonly Pajaro _pajaro;

        // Constructor con inyección de dependencias
        public PajarosVersion3Controller(Pajaro pajaro)
        {
            _pajaro = pajaro;
        }
        public IActionResult Index()
        {
            // Obtener los datos desde el repositorio
            var birds = _pajaro.GetAllBirds();

            // Pasar la lista de pájaros a la vista
            // Observar como el framework busca la vista en Views/PajarosVersion2/Index.cshtml 
            // asumiendo que el nombre de la misma es Index.cshtml (mismo nombre que el método)
            return View(birds);
        }
    }
}
