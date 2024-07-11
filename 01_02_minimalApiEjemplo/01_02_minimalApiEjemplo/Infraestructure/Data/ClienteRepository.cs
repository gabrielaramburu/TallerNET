using _01_02_minimalApiEjemplo.Models;

namespace _01_02_minimalApiEjemplo.Infraestructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private IList<Cliente> _clientes;

        public ClienteRepository()
        {
            this._clientes = new List<Cliente>();

            this._clientes.Add(new Cliente(1, "cli1", "111111"));
            this._clientes.Add(new Cliente(2, "cli2", "222222"));
            this._clientes.Add(new Cliente(3, "cli3", "333333"));
        }

        public void Add(Cliente cliente)
        {
            this._clientes.Add(cliente);
        }

        public Cliente Get(int id)
        {
            return this._clientes[id];
        }

        public void Delete(int id)
        {
            this._clientes.RemoveAt(id);
        }

        public IList<Cliente> GetClientes() { return this._clientes; }

    }
}

