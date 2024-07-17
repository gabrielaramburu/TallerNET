namespace _01_3_webAppEjemplo.Models
{
    public interface IVehiculoRepository
    {
        public void Add(Vehiculo vehiculo);

        public Vehiculo Get(String matricula);

        public void Delete(String matricula);

        public IList<Vehiculo> GetVehiculos();
    }
}
