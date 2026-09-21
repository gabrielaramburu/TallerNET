using System.Text.Json.Serialization;

namespace DemoSesion.Models;

//Observar como se utiliza el atributo [JsonInclude] para permitir la serialización de la propiedad Valor,
//Esto se debe a que en ASP.NET Core solo puedo guardar en session tipos primitivos
//Un objeto no es un tipo primitivo, entonces como lo guardamos?: serelizando el mismo, es decir
//transformando el objeto a un String. En este caso a un JSON. Nos ayudamos de la clase System.Text.Json.JsonSerializer para hacer esto.
//Por eso es necesario que la propiedad Valor tenga el atributo [JsonInclude] para que pueda ser serializada y deserializada correctamente.
public class Contador
{
    [JsonInclude]
    public int Valor { get; private set; }

    public Contador()
    {
        Valor = 0;
    }

    [JsonConstructor]
    public Contador(int valor)
    {
        Valor = valor;
    }

    public void Incrementar()
    {
        Valor++;
    }
}
