using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using ServerHub.Hubs;
namespace ServerHub.Messaging
{
    public class ColaRabbitMQ
    {
        private readonly RabbitMQ.Client.IConnection _connection;
        private readonly ILogger<PanelControlHub> _logger;

        public  ColaRabbitMQ(RabbitMQ.Client.IConnection connection, ILogger<PanelControlHub> _logger)
        {
           this._logger = _logger;
           this._connection = connection;
        }

        public void GenerarEvento(int idSensor, int temperatura)
        {
            var infoEvento = $"idSensor={idSensor}, temperatura={temperatura}";
            _logger.LogInformation($"Nuevo evento: {infoEvento}");
        
            var body = Encoding.UTF8.GetBytes(infoEvento);

            var aux = _connection.CreateModel();

            aux.QueueDeclare(queue: "cambioTemperaturaEnvento",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            aux.BasicPublish(exchange: string.Empty,
                                 routingKey: "cambioTemperaturaEnvento",
                                  mandatory: false,
                                 basicProperties: null,
                                 body: body);
        }
    }

   
}
