namespace _01_3_webAppEjemplo.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public Persona(int Id, int Documento, string Nombre, string Apellido, string Telefono)
        {
            this.Id = Id;
            this.Documento = Documento;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
        }
    }
}
