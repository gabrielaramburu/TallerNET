namespace DemoPartialPages.Models;

/// <summary>
/// Clase base abstracta que modela los atributos y comportamientos comunes de todos los vehículos.
/// Demuestra conceptos de POO: Abstracción, Encapsulamiento y Polimorfismo.
/// </summary>
public abstract class Vehiculo
{
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public string Patente { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Propiedad abstracta que cada clase derivada debe implementar para identificar su categoría.
    /// </summary>
    public abstract string TipoVehiculo { get; }

    /// <summary>
    /// Método polimórfico que devuelve un resumen específico de las características distintivas del tipo de vehículo.
    /// </summary>
    public abstract string ObtenerResumenEspecifico();

    /// <summary>
    /// Método virtual con implementación base para el nombre descriptivo.
    /// </summary>
    public virtual string ObtenerNombreCompleto()
    {
        return $"{Marca} {Modelo} ({Anio})";
    }
}
