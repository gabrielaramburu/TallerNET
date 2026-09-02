namespace DemoPartialPages.Models.ViewModels;

/// <summary>
/// Modelo de vista para la pantalla principal de vehículos.
/// </summary>
public class VehiculosIndexViewModel
{
    public IEnumerable<Vehiculo> Vehiculos { get; set; } = Enumerable.Empty<Vehiculo>();

    public Vehiculo? VehiculoSeleccionado { get; set; }

    //propiedad de solo lectura que devuelve el Id del vehículo seleccionado,
    //o null si no hay ninguno seleccionado
    public int? VehiculoSeleccionadoId => VehiculoSeleccionado?.Id;
}
