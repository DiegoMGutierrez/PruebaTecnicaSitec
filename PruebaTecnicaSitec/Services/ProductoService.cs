using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ContextoDb _db;
        public ProductoService(ContextoDb db)
        {
            _db = db;
        }

        public List<Producto> GetProductos()
        {
            return (_db.Productos.ToList());
        }

        public Producto PostProducto(Producto body)
        {
            _db.Productos.Add(body);
            _db.SaveChanges();
            return body;
        }

        public Producto PutProducto(int id, Producto body)
        {
            var ProductoFromDb = _db.Productos.Find(id);
            if (ProductoFromDb != null)
            {
                ProductoFromDb.NombreProducto = body.NombreProducto;
                ProductoFromDb.DescripcionProducto = body.DescripcionProducto;
                ProductoFromDb.StockProducto = body.StockProducto;
                ProductoFromDb.PrecioProducto = body.PrecioProducto;
                ProductoFromDb.IdCategoria = body.IdCategoria;

                _db.Update(ProductoFromDb);
                _db.SaveChanges();
                return (ProductoFromDb);
            }
            else return null;
        }

        public Producto DeleteProducto(int id)
        {
            var ProductoFromDb = _db.Productos.Find(id);
            if (ProductoFromDb != null)
            {
                _db.Remove(ProductoFromDb);
                _db.SaveChanges();
                return (ProductoFromDb);
            }
            else return null;
        }

        public Producto PatchStock(int id, int NuevoStock)
        {
            var ProductoFromDb = _db.Productos.Find(id);
            if (ProductoFromDb != null)
            {
                ProductoFromDb.StockProducto = NuevoStock;
                _db.Update(ProductoFromDb);
                _db.SaveChanges();
                return ProductoFromDb;
            }
            else return null;
        }

        public Producto PatchPrecio(int id, decimal NuevoPrecio)
        {
            var ProductoFromDb = _db.Productos.Find(id);
            if (ProductoFromDb != null)
            {
                ProductoFromDb.PrecioProducto = NuevoPrecio;
                _db.Update(ProductoFromDb);
                _db.SaveChanges();
                return ProductoFromDb;
            }
            else return null;
        }
    }
}
