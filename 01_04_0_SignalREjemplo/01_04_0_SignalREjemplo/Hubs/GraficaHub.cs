using Microsoft.AspNetCore.SignalR;

namespace _01_04_0_SignalREjemplo.Hubs
{
    //Clase que interactua con los clientes SignalR
    //Notar que hereda de Hub
    public class GraficaHub: Hub
    {
       //en este ejemplo no recibo datos del cliente, por eso no tiene métodos
    }
}
