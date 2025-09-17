namespace EjemploBlazorConEntityFramework.Model
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorActual { get; set; }
        public bool Prendido { get; set; }
    }
}
