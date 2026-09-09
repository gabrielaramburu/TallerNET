using Microsoft.AspNetCore.SignalR;

namespace _01_04_0_SignalREjemplo.Hubs
{
    public class ChatHub: Hub
    {
        //Este método queda disponible para ser invocado por cada uno de los clientes conectados
        //al hub
        //Cada vez que un cliente invoca este método, el hub redirecciona el mensaje a todos los clientes
        //Esto es así porque este ejemplo simula un chat muy básico.
        public async Task EnviarMensaje(string user, string message)
        {
            //podría crear una versión mejor de este char para indicar que el mensaje no me lo envíe a mi
            //mismo, sino a todos los demás clientes conectados al hub
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
