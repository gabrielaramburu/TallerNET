namespace ApiUniversidad.Modelos;

public class Materia
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public InfoExamen? Examen { get; set; }
}
