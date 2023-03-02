using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public class VentaProductoService:IVentaProductoService
    {
        private readonly ContextoDb _db;
        public VentaProductoService(ContextoDb db)
        {
            _db = db;
        }

        public List<VentaProducto> GetPorIdVenta(int id)
        {
            return (_db.VentaProductos.Where(x=>x.IdVenta==id).ToList());
        }
        public List<VentaProducto> GetPorIdProducto(int id)
        {
            return (_db.VentaProductos.Where(x => x.IdProducto == id).ToList());
        }
        public List<VentaProducto> GetPorIdCliente(int id)
        {
            return (_db.VentaProductos.FromSqlRaw($"select vp.* from public.\"VentaProductos\" as vp, " +
                $"public.\"Ventas\" as v where v.\"IdVenta\" = vp.\"IdVenta\" and v.\"IdCliente\" = " + id.ToString())
                .ToList());
        }

        public VentaProducto PostVentaProducto(VentaProducto body)
        {
            _db.VentaProductos.Add(body);
            _db.SaveChanges();
            return (body);
        }

    }
}
