using _01_04_2_SignalREjemploVotacion.Model;
using Microsoft.AspNetCore.SignalR;
namespace _01_04_2_SignalREjemploVotacion.Hubs
{
    public class RealTimeEncuestaHub: Hub
    {
        private readonly ILogger<RealTimeEncuestaHub> _logger;
        private Encuesta _encuesta;

        public RealTimeEncuestaHub(ILogger<RealTimeEncuestaHub> logger, Encuesta encuesta)
        {
            _logger = logger;
            _encuesta = encuesta;
        }

        public void Votar(int elementoId)
        {
            string descParticipante = this._encuesta.ObtenerDescripcionParticipante(elementoId);
            _logger.LogInformation($"Se voto por participante: {elementoId} {descParticipante}");
            //incremento en uno la cantidad de votos para el elemento
            this._encuesta.Votar(elementoId);


            int[] votosActuales = this._encuesta.ObtenerVotosActuales();

            var contenido = String.Join(" ", votosActuales.ToList());
            _logger.LogInformation($"Votos actuales: {contenido}");

            //notifico a todos los clientes que hay una nueva votación
            Clients.All.SendAsync("RefrescarGrafica", votosActuales);

        }
    }
}
