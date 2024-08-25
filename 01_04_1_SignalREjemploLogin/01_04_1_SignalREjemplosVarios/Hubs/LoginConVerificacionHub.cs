using _01_04_1_SignalREjemplosVarios.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace _01_04_1_SignalREjemplosVarios.Hubs
{
    public class LoginConVerificacionHub  : Hub
    {
        private readonly ILogger<LoginConVerificacionHub> _logger;

        public LoginConVerificacionHub(ILogger<LoginConVerificacionHub> logger)
        {
            _logger = logger;
        }

        public void Login(String email, String pass) {
            _logger.LogInformation("SignalR identificacion del usuario: " + Context.ConnectionId);
            Usuario usr = new Usuario(email, pass);
            if (usr.EsUsuarioValido())
            {
                if (usr.NecesitarVerificacion())
                {
                    //TODO
                    //mando mail al cliente
                    string usrId = Context.ConnectionId;
                    _logger.LogInformation($"**** Copiar la siguiente url para probar");
                    //NOTA: esto es solo a fines demostrativos
                    //Enviar una identificación de usuario en la url no es una buena práctica
                    //Si bien la misma viaja encriptada, la url queda en el historial del browser
                    _logger.LogInformation($"curl https://localhost:7269/verificar/usuario/{usrId}");
                }
            };
        }

        public void EnviarVerificacionOk()
        {
            Clients.User(Context.UserIdentifier).SendAsync("VerificacionOk", "");
        }
    }
}
