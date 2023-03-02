using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public class CategoriaService:ICategoriaService
    {
        private readonly ContextoDb _db;
        public CategoriaService(ContextoDb db)
        {
            _db = db;
        }

        public List<Categoria> GetCategorias()
        {
            return _db.Categorias.ToList();
        }
    }
}
