namespace _08_demo_mvc_seguridad_OpenID.Models;

/// <summary>
/// Representa un curso en la plataforma educativa.
/// </summary>
public class Curso
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string DescripcionCorta { get; set; } = string.Empty;
    public string DescripcionCompleta { get; set; } = string.Empty;
    
    // Tipado fuerte con Enum
    public NivelCurso Nivel { get; set; } = NivelCurso.Principiante;
    
    public int HorasEstimadas { get; set; }
    
    // Asociación pura de POO con la entidad Docente
    public Docente Docente { get; set; } = null!;

    //TODO: esto debería ser un Enum, 
    //lo dejo sin modificar para ver como el LLM genera código sin utilizar los mejores patrones de diseño
    //y buenas prácticas. Lo dejo para que quede como ejemplo de que hay que analizar el código generado automáticamente.
    //Además se debería de escribir una regla de estilo para evitar este tipo de "errores" en el código generado automáticamente.
    public string Categoria { get; set; } = "Desarrollo";

    //TODO: observar como el LLM mezacla atributos que solo interesan a la vista con atributros del modelo de dominio,
    //esto es un error de diseño, se debería de separar la vista del modelo de dominio.
    //Este atributo debería de estar en un ViewModel, no en el modelo de dominio.
    //Lo dejo para que quede como ejemplo de que hay que analizar el código generado automáticamente.
    //El framwork MVC no ayuda a mantener una separación clara entre el modelo, vista y controlador, 
    //pero si no tenemos cuidado tampoco "hace magia".
    public string IconoBootstrap { get; set; } = "bi-journal-code";
}
