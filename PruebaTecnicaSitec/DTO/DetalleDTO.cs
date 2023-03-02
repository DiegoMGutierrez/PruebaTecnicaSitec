using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.DTO
{
    public class DetalleDTO
    {
        public Venta? Venta { get; set; }
        public List<VentaProducto>?  Productos { get; set; } = new List<VentaProducto>();
    }
}
