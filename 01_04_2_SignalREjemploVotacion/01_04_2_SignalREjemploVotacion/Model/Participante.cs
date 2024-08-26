namespace _01_04_2_SignalREjemploVotacion.Model
{
    public class Participante
    {
        public string Descripcion { get; set; }
        public int CantidadVotos { get; set; }

        public Participante (string descripcion, int cantidadVotos)
        {
            Descripcion = descripcion;
            CantidadVotos = cantidadVotos;
        }

        public void RegistrarNuevoVoto()
        {
            this.CantidadVotos++;
        }
    }
}
