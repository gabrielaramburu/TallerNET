namespace ServerHub.Models
{
    public interface IPanelControl
    {
        public void AgregarSensor(string idConn, int idSensor);
        public Sensor ObtenerSensor(int idSensor);

        public IList<Sensor> ObtenerSensores();

        public void CambioTemperatura(int idSensor, int temp);

        // declaro un evento, para lanzarlo cada vez que el hub recive un cambio de estado del 
        //sensor
        public event EventHandler<int> CambioEnSensorEvento;
       


    }
}
