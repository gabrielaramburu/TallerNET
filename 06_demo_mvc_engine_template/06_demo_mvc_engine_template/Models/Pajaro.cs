using Microsoft.Data.Sqlite;

//Microsoft.Data es la tecnología que nos permite conectarnos a base de datos desde .NET.
//En este caso, se está utilizando para conectarse a una base de datos SQLite.
//Piense en Microsoft.Data como el quivalente a JDBC en Java.


namespace _06_demo_mvc_engine_template.Models
{
    public class Pajaro
    {
       

        public Pajaro()
        {
            
        }

        public List<(string Name, string Species, int Age)> GetAllBirds()
        {
            //observar que por simplicidad no se agregó una capa de datos ni un repositorio,
            //sino que el modelo mismo se encarga de acceder a la base de datos.
            //Esto no es una buena práctica en aplicaciones más grandes, pero sirve para fines de demostración.
            var birds = new List<(string Name, string Species, int Age)>();
            var query = "SELECT Name, Species, Age FROM Birds";

            //creo conexión
            using (var connection = new SqliteConnection("Data Source=ejemploPajaros.db;"))
            {
                //abro conexión
                connection.Open();
                using (var command = new SqliteCommand(query, connection))
                {
                    //ejecuto consulta
                    using (var reader = command.ExecuteReader())
                    {
                        //itero sobre el datareader para obtener los datos de cada fila y agregarlos a la lista de pájaros.
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string species = reader.GetString(1);
                            int age = reader.GetInt32(2);
                            birds.Add((name, species, age));
                        }
                    }
                }
            }

            return birds;
        }
    }
}
