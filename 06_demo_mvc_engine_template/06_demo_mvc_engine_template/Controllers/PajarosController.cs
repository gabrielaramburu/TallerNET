using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Text;

namespace _06_demo_mvc_engine_template.Controllers
{
    public class PajarosController : Controller
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

            // Generar el HTML manualmente
            var html = new StringBuilder();
            html.Append("<!DOCTYPE html>");
            html.Append("<html lang='es'>");
            html.Append("<head>");
            html.Append("<meta charset='UTF-8'>");
            html.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            html.Append("<title>Información de Pájaros</title>");
            html.Append("<style>");
            html.Append("body { font-family: Arial, sans-serif; margin: 20px; }");
            html.Append("h1 { color: #2c3e50; }");
            html.Append("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            html.Append("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            html.Append("th { background-color: #f4f4f4; }");
            html.Append(".highlight { background-color: #ffeb3b; }"); // Clase CSS para resaltar filas
            html.Append("</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h1>Información de Pájaros</h1>");
            html.Append("<p>Esta es una demostración de cómo se generaba HTML antes de los frameworks MVC.</p>");
            html.Append("<table>");
            html.Append("<thead>");
            html.Append("<tr>");
            html.Append("<th>Nombre</th>");
            html.Append("<th>Especie</th>");
            html.Append("<th>Edad</th>");
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");

            // Generar filas de la tabla con la información de la lista
            foreach (var bird in birds)
            {
                var rowClass = bird.Age >= 5 ? "class='highlight'" : ""; // Aplicar clase si la edad es mayor a 5
                html.Append($"<tr {rowClass}>");
                html.Append($"<td>{bird.Name}</td>");
                html.Append($"<td>{bird.Species}</td>");
                html.Append($"<td>{bird.Age}</td>");
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            html.Append("</table>");
            html.Append("</body>");
            html.Append("</html>");

            // Devolver el HTML como respuesta
            return Content(html.ToString(), "text/html");
        }
    }
}
