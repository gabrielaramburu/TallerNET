namespace ApiUniversidad.Modelos;

public class InfoExamen
{
    public string FechaProximoExamen { get; set; } = string.Empty;
    public string[] Temas { get; set; } = System.Array.Empty<string>();
}
