namespace DemoPartialPages.Models;

/// <summary>
/// Especialización de Vehículo para utilitarios y vehículos comerciales livianos.
/// </summary>
public class Utilitario : Vehiculo
{
    public double CapacidadCargaKg { get; set; }
    public double VolumenCargaM3 { get; set; }
    public bool TienePuertaLateral { get; set; }
    public bool EsFurgonCerrado { get; set; }

    public override string TipoVehiculo => "Utilitario";

    public override string ObtenerResumenEspecifico()
    {
        string tipoCarroceria = EsFurgonCerrado ? "Furgón Cerrado" : "Pick-up / Abierto";
        string puerta = TienePuertaLateral ? "Con puerta lateral corrediza" : "Sin puerta lateral";
        return $"Capacidad: {CapacidadCargaKg:N0} kg, Volumen: {VolumenCargaM3:N1} m³, Tipo: {tipoCarroceria}, {puerta}";
    }
}
