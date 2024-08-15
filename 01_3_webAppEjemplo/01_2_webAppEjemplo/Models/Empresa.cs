namespace _01_3_webAppEjemplo.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public bool? AtiendePublico { get; set; }

        public DateOnly? FechaFundacion { get; set; }
    }
}
