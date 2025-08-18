using Microsoft.Data.Sqlite;

namespace _06_demo_mvc_engine_template.Models
{
    public class Pajaro
    {
       

        public Pajaro()
        {
            
        }

        public List<(string Name, string Species, int Age)> GetAllBirds()
        {
            var birds = new List<(string Name, string Species, int Age)>();
            var query = "SELECT Name, Species, Age FROM Birds";

            using (var connection = new SqliteConnection("Data Source=ejemploPajaros.db;"))
            {
                connection.Open();
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
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
