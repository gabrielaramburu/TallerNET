namespace ApiUniversidad.Modelos;

public class HorarioApoyo
{
    public Materia? Materia { get; set; }
    public string[] DiasDisponibles { get; set; } = System.Array.Empty<string>();
}
