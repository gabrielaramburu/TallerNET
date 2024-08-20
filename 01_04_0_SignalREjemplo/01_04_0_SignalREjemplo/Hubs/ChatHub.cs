using Microsoft.AspNetCore.SignalR;

namespace _01_04_0_SignalREjemplo.Hubs
{
    public class ChatHub: Hub
    {
        //Este método puede ser llamado por todos los clientes conectados
        //para enviar mensajes a todos los clientes
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
