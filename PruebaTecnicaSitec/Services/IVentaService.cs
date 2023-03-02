using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public interface IVentaService
    {
        List<Venta> GetVentas();
        List<Venta> GetVentasPorProducto(int id);
        List<Venta> GetVentasPorCliente(int id);
        Venta PostVenta(Venta body);
    }
}
