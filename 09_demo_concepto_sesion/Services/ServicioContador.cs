using DemoSesion.Models;

namespace DemoSesion.Services;

public class ServicioContador : IServicioContador
{
    public Contador Contador { get; } = new();

    public void Incrementar()
    {
        Contador.Incrementar();
    }
}
