namespace DemoPartialPages.Models;

/// <summary>
/// Especialización de Vehículo para camiones y transporte pesado.
/// </summary>
public class Camion : Vehiculo
{
    public int CantidadEjes { get; set; }
    public double CapacidadToneladas { get; set; }
    public bool TieneAcoplado { get; set; }
    public string TipoCabina { get; set; } = "Simple";

    public override string TipoVehiculo => "Camión";

    public override string ObtenerResumenEspecifico()
    {
        string acoplado = TieneAcoplado ? "Con acoplado incluido" : "Sin acoplado";
        return $"Ejes: {CantidadEjes}, Capacidad: {CapacidadToneladas:N1} Tn, Cabina: {TipoCabina}, {acoplado}";
    }
}
