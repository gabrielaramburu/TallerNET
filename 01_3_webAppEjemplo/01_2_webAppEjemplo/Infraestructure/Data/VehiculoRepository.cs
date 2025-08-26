using _01_3_webAppEjemplo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace _01_3_webAppEjemplo.Infraestructure.Data
{
    //observar como esta clase está declarada como servicio singleton en Program.cs
    //en el controlador voy a utilizar el servicio inyectado el mismo. (ver VehiculoController)
    public class VehiculoRepository : IVehiculoRepository
    {
        private IDictionary<String, Vehiculo> _vehiculos;

        public VehiculoRepository() {
            // notese el uso de estructura map
            _vehiculos = new Dictionary<String, Vehiculo>();
            Vehiculo v1 = new Vehiculo("BAA 1111", "Palio", "Fiat", 2010);
            Vehiculo v2 = new Vehiculo("BAA 2222", "Civic", "Honda", 2015);
            Vehiculo v3 = new Vehiculo("BAA 3333", "Corolla", "Toyota", 2018);
            Vehiculo v4 = new Vehiculo("BAA 4444", "Golf", "Volkswagen", 2020);
            Vehiculo v5 = new Vehiculo("BAA 5555", "Fiesta", "Ford", 2017);
            Vehiculo v6 = new Vehiculo("BAA 6666", "Camry", "Toyota", 2019);
            Vehiculo v7 = new Vehiculo("BAA 7777", "Palio", "Fiat", 2010);

            this._vehiculos.Add(v1.Matricula, v1);
            this._vehiculos.Add(v2.Matricula, v2);
            this._vehiculos.Add(v3.Matricula, v3);
            this._vehiculos.Add(v4.Matricula, v4);
            this._vehiculos.Add(v5.Matricula, v5);
            this._vehiculos.Add(v6.Matricula, v6);
            this._vehiculos.Add(v7.Matricula, v7);
        }

        public void Add(Vehiculo vehiculo)
        {
            this._vehiculos.Add(vehiculo.Matricula, vehiculo);
        }

        public void Delete(string matricula)
        {
           this._vehiculos.Remove(matricula);
        }

        public Vehiculo Get(string matricula)
        {
            Vehiculo respuesta;
            //hay varias maneras de buscar un elemento en un map
            //la otra alternativa es _vehiculos[matricula] pero hay que realizar manejo de excepciones
            this._vehiculos.TryGetValue(matricula, out respuesta);
            return respuesta;
        }

        public IList<Vehiculo> GetVehiculos()
        {
            return this._vehiculos.Values.ToList();
        }
    }
}
