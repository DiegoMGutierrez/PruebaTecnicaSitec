using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public interface IVentaProductoService
    {
        List<VentaProducto> GetPorIdVenta(int id);
        List<VentaProducto> GetPorIdProducto(int id);
        List<VentaProducto> GetPorIdCliente(int id);

        VentaProducto PostVentaProducto(VentaProducto body);
    }
}
