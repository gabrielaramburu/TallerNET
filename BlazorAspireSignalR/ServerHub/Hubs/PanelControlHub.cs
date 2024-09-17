using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using ServerHub.Messaging;
using ServerHub.Models;

using System.Threading.Channels;
namespace ServerHub.Hubs
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class PanelControlHub: Hub
    {
        private readonly ILogger<PanelControlHub> _logger;
        private readonly IPanelControl _panelControl;
        private readonly ColaRabbitMQ _colaMensajes;

        public PanelControlHub(
            ILogger<PanelControlHub> logger, 
            IPanelControl panel,
            ColaRabbitMQ colaMensajes)
        {
            _panelControl = panel;
            _logger = logger;
            _colaMensajes = colaMensajes; //recordar que lo puedo inyectar porque lo agregué
            //como servicio en Program.cs
        }

        public void NuevoRegistroTemperatura(int idSensor, int temperatura)
        {

        }

        // Se invoca desde cada sensor luego de iniciado el mismo
        // (establecida la conexión)
        public void Registrar(int idSensor)
        {
            string connId = Context.ConnectionId;
            _logger.LogInformation("Se registra nuevo sensor, idSensor: {id}: , connectionId: {conn}", idSensor, connId);
            
            this._panelControl.AgregarSensor(connId, idSensor);

        }

        public void CambioTemperatura(int idSensor, int temperatura)
        {
        
            _logger.LogInformation("Se registra nuevo cambio temperatura, temperatura: {temp}: , idSensor: {conn}", temperatura, idSensor);
            this._panelControl.CambioTemperatura(idSensor, temperatura);

            //envío envento
            this._colaMensajes.GenerarEvento(idSensor, temperatura);
            
           

        }
    }
}
