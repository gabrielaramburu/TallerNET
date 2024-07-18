namespace _01_3_webAppEjemplo.Models
{
    public class Vehiculo
    {
        public String Matricula { get; set; }
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public int AnioFabricacion { get; set; }

        public Vehiculo(String matricula, String modelo, String marca, int anio) { 
            this.Matricula = matricula;
            this.Modelo = modelo;
            this.Marca = marca;
            this.AnioFabricacion = anio;
        }

        // es necesario tener un costructor por defecto para que el binding desde la vista al controlador funcione
        public Vehiculo()
        {

        }
   

    }
}
