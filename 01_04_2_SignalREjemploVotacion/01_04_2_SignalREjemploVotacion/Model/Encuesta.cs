using _01_04_2_SignalREjemploVotacion.Hubs;
using System.Diagnostics.Eventing.Reader;

namespace _01_04_2_SignalREjemploVotacion.Model
{
    public class Encuesta
    {
        private Participante[] _participantes;

        private  ILogger<Participante> _logger { get; set; }

      
        public Encuesta() { 
            this._participantes = new Participante[5];
            this._participantes[0] = new Participante("ChatGPT",0);
            this._participantes[1] = new Participante("DALLE",0);
            this._participantes[2] = new Participante("Midjourney", 0);
            this._participantes[3] = new Participante("GithubCopilot", 0);
            this._participantes[4] = new Participante("Jasper", 0);
        }

        public void Votar(int indicePartcipante)
        {
            if (indicePartcipante < 0 && indicePartcipante >= this._participantes.Length) { 
                _logger.LogInformation("Voto incorrecto, no existe el participante");
                
            } else
            {
                this._participantes[indicePartcipante].RegistrarNuevoVoto();
            }
        }

        public string ObtenerDescripcionParticipante(int indicePartcipante)
        {
            return this._participantes[indicePartcipante].Descripcion;
        }

        public int[] ObtenerVotosActuales()
        {
            //Select es una expresión LINQ
            //por cada elemnto de la lista, obtengo la cantidad de vatos y genero un array nuevo
            //que contenga solo este valor
            //Es una manera de utilizar estilo funcionl

            int[] votos = new int[this._participantes.Length];
            return this._participantes.Select( v => v.CantidadVotos).ToArray();
        }
    }
}
