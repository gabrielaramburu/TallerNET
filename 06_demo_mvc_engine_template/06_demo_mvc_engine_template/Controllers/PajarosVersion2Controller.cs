using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Text;

namespace _06_demo_mvc_engine_template.Controllers
{
   
    public class PajarosVersion2Controller : Controller
    {
        public IActionResult Index()
        {
            // Cadena de conexión a la base de datos SQLite
            var connectionString = "Data Source=ejemploPajaros.db;";

            // Lista para almacenar los datos de la base de datos
            var birds = new List<(string Name, string Species, int Age)>();

            // Consulta SQL para obtener los datos
            var query = "SELECT Name, Species, Age FROM Birds";

            // Conexión y ejecución de la consulta
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0); // Columna Name
                            string species = reader.GetString(1); // Columna Species
                            int age = reader.GetInt32(2); // Columna Age
                            birds.Add((name, species, age));
                        }
                    }
                }
            }

            // Pasar la lista de pájaros a la vista
            // Observar como el framework busca la vista en Views/PajarosVersion2/Index.cshtml 
            // asumiendo que el nombre de la misma es Index.cshtml (mismo nombre que el método)
            return View(birds);
        }
    }
}
