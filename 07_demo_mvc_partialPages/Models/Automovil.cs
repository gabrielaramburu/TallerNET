namespace DemoPartialPages.Models;

/// <summary>
/// Especialización de Vehículo para automóviles particulares.
/// </summary>
public class Automovil : Vehiculo
{
    public int CantidadPuertas { get; set; }
    public TipoCombustible Combustible { get; set; }
    public bool TieneCajaAutomatica { get; set; }
    public bool TieneAireAcondicionado { get; set; }

    public override string TipoVehiculo => "Automóvil";

    public override string ObtenerResumenEspecifico()
    {
        string transmision = TieneCajaAutomatica ? "Automática" : "Manual";
        string ac = TieneAireAcondicionado ? "Con A/C" : "Sin A/C";
        return $"{CantidadPuertas} puertas, Combustible: {Combustible}, Caja: {transmision}, {ac}";
    }
}
