using EjemploBlazorConEntityFramework.Model;
namespace EjemploBlazorConEntityFramework.Infrastructure.Data
{
    public class SensorService
    {
        //acordarse de agregar este servicio a Program.cs

        //El servicio de declara asyncronico pero no es necesario que sea así.
        public Task<Sensor[]> GetSesonsoresAsync()
        {
            return null;
        }
    }
}
