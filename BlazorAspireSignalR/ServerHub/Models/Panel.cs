namespace ServerHub.Models
{
    public class Panel:IPanelControl
    {
        private Dictionary<int, Sensor> _sensores;
        public event EventHandler<int> CambioEnSensorEvento;

        public Panel() {
            _sensores = new Dictionary<int, Sensor>();
        }

        public void AgregarSensor(string idConn, int idSensor)
        {
            Sensor sensor = new Sensor(idSensor, "Sensor nro. " + idSensor, idConn, 0);
            this._sensores.Add(idSensor, sensor);

            //lanzo un evento para notificar a la página Panel de Control que hay un nuevo sensor
            CambioEnSensorEvento.Invoke(this, idSensor);
        }

        public Sensor ObtenerSensor(int idSensor)
        {
            return _sensores[idSensor];
        }

        public IList<Sensor> ObtenerSensores()
        {
            return _sensores.Values.ToList();
        }

        public void CambioTemperatura(int idSensor, int temp)
        {
            _sensores[idSensor].TemperaturaActual = temp;
            //lanzo evento para que se actualize la página, podría utilizar un solo evento
            //(notar que hay otro even
            CambioEnSensorEvento.Invoke(this, idSensor);
        }
        
    }
}
