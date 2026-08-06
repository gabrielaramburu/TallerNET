using System.Collections.Generic;

namespace ApiUniversidad.Modelos;

public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public List<Materia> MateriasQueDicta { get; set; } = new List<Materia>();
}
