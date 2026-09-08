namespace _08_demo_mvc_seguridad_OpenID.Models;

//TODO:
//No hay una convención estricta para la ubicación de esta clase, 
//pero se suele colocar en la carpeta Models o ViewModels, dependiendo de la estructura del proyecto y de cómo se quiera organizar el código.
//En este caso el LLM no ha mantenido una choerencia ya que existe la carpeta ViewModels,
//no la muevo para que quede como un ejemplo de cómo hay que tener cuidado con el código generado automáticamente.
//Se debería de agregar una regla de estilo para que el LLM no genere código en carpetas que no correspondan a la ubicación de la clase.

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
