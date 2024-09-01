using Microsoft.AspNetCore.SignalR;

namespace _01_4b_BlazorServerSignalR_Grafica.Hubs
{
    public class SensorHub: Hub
    {
        public void NotificarCambioTemperatura(int temperatura)
        {
            Clients.All.SendAsync("CambioTemperatura", temperatura);
        }
    }
}
