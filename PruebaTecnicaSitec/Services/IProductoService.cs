using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Services
{
    public interface IProductoService
    {
        List<Producto> GetProductos();
        Producto PostProducto(Producto body);
        Producto PutProducto(int id,Producto body);
        Producto DeleteProducto(int id);
        Producto PatchStock(int id, int NuevoStock);
        Producto PatchPrecio(int id, decimal NuevoPrecio);
    }
}
