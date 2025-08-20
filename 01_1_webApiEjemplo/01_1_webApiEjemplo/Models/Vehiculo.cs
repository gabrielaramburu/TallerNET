namespace _01_1_webApiEjemplo.Models
{
    public class Vehiculo
    {
        private long _id; //atributo

        public long Id
        { // esto es un propiedad, la cual define el setter y getter para el atributo
            set { _id = value; }
            get { return _id; }

        }

        // lo anterior se puede tambien escribir de la siguiente manera:
        //public long Id {get; set;} 
        // en este caso no es necesario definir el campo ya que se crea de forma automatica con el nombre Id

        //notese que los siguientes miembros de la clase comienzan con mayúsculas ya que son propiedades 
        // (no son atributos)

        public string? Matricula { get; set; }   //? significa que el atributo puede contener valores nulos 
        public string? Marca { get; set; }

       
        public Vehiculo(int id, string matricula, string marca)
        {
            this._id = id;
            this.Matricula = matricula;
            this.Marca = marca;
        
        }

        public Vehiculo() //necesario para la descerealizacion
        {
        }
            

    }
}
