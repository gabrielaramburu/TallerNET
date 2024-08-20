using Microsoft.AspNetCore.SignalR;

namespace _01_04_0_SignalREjemplo.Hubs
{
    public class ChatHub: Hub
    {
        //Este método queda disponible para ser invocado por cada uno de los clientes conectados
        //al hub
        //Cada vez que un cliente invoca este método, el hug redirecciona el mensaje a todos los clientes
        //Esto es así porque este ejemplo simula un chat.
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
