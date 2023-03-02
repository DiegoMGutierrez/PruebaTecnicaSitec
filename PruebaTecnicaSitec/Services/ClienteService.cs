using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public class ClienteService:IClienteService
    {
        private readonly ContextoDb _db;

        public ClienteService(ContextoDb db)
        {
            _db = db;
        }

        public List<Cliente> GetClientes()
        {
            return _db.Clientes.ToList();
        }
    }
}
