namespace DemoPartialPages.Models.ViewModels;

/// <summary>
/// Modelo de vista para la pantalla principal de vehículos.
/// </summary>
public class VehiculosIndexViewModel
{
    public IEnumerable<Vehiculo> Vehiculos { get; set; } = Enumerable.Empty<Vehiculo>();

    public Vehiculo? VehiculoSeleccionado { get; set; }

    public int? VehiculoSeleccionadoId => VehiculoSeleccionado?.Id;
}
