using DemoPartialPages.Models;

namespace DemoPartialPages.Repositories;

/// <summary>
/// Contrato del Repositorio de Vehículos.
/// Abstrae el acceso a los datos permitiendo que los controladores dependan de esta interfaz
/// y no de una implementación concreta de persistencia (Principio de Inversión de Dependencias).
/// </summary>
public interface IVehiculoRepository
{
    /// <summary>
    /// Devuelve todos los vehículos registrados en el almacén de datos.
    /// </summary>
    IEnumerable<Vehiculo> ObtenerTodos();

    /// <summary>
    /// Busca un vehículo por su identificador único.
    /// </summary>
    /// <param name="id">Identificador del vehículo.</param>
    /// <returns>El vehículo si existe, o null si no se encuentra.</returns>
    Vehiculo? ObtenerPorId(int id);
}
