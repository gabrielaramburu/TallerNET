using Microsoft.AspNetCore.SignalR;

namespace _01_04_0_SignalREjemplo.Hubs
{
    //Clase que interactua con los clientes SignalR
    //Notar que hereda de Hub
    public class GraficaHub: Hub
    {
       //En este ejemplo sencillo, los clientes no envian mensajes al servidor
       //por eso esta clase no tiene métodos
    }
}
