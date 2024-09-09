namespace ServerHub.Models
{
    public class Sensor 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public int TemperaturaActual { get; set; }

        public string ConexionID { get; set; }

        public Sensor(int id, string nombre, string connId, int tempActual)
        {
            Id = id;
            Nombre = nombre;
            ConexionID = connId;
            TemperaturaActual = tempActual;
        }
 
     
    }
}
