namespace _01_02_minimalApiEjemplo.Models
{
    public interface IClienteRepository
    {
        public void Add(Cliente cliente);

        public Cliente Get(int id);

        public void Delete(int id);

        public IList<Cliente> GetClientes();
    }
}
