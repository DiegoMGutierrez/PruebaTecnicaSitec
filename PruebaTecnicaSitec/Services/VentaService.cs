using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public class VentaService:IVentaService
    {
        private readonly ContextoDb _db;
        public VentaService(ContextoDb db)
        {
            _db = db;
        }

        public List<Venta> GetVentas()
        {
            return _db.Ventas.ToList();
        }

        public List<Venta> GetVentasPorCliente(int id)
        {
            return _db.Ventas.Where(x => x.IdCliente == id).ToList();
        }

        public List<Venta> GetVentasPorProducto(int id)
        {

            return (_db.Ventas.FromSqlRaw($"select v.* from public.\"VentaProductos\" as vp, " +
                $"public.\"Ventas\" as v where v.\"IdVenta\" = vp.\"IdVenta\" and vp.\"IdProducto\" = " + id.ToString())
                .ToList());
        }

        public Venta PostVenta(Venta body)
        {
            _db.Ventas.Add(body);
            _db.SaveChanges();
            return (body);
        }
    }
}
