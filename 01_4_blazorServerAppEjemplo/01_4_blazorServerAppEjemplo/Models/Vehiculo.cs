using System.ComponentModel.DataAnnotations;

namespace _01_4_blazorServerAppEjemplo.Models
{
    public class Vehiculo
    {
        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }

        public Vehiculo() { }

        public Vehiculo(string matricula, string marca, string modelo, int anioFabricacion)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            AnioFabricacion = anioFabricacion;
        }
    }
}
