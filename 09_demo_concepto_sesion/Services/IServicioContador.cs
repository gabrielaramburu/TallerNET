using DemoSesion.Models;

namespace DemoSesion.Services;

public interface IServicioContador
{
    Contador Contador { get; }
    void Incrementar();
}
