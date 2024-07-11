namespace _01_02_minimalApiEjemplo.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ci {  get; set; }

        public ClienteDTO(int id, string nombre, string ci)
        {
            Id = id;
            Nombre = nombre;
            Ci = ci;
        }

        public ClienteDTO()
        {

        }
    }
}
