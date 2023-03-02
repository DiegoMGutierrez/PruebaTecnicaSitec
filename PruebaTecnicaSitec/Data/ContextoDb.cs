using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitec.Models;

namespace PruebaTecnicaSitec.Data
{
    public class ContextoDb:DbContext
    {
        public ContextoDb(DbContextOptions<ContextoDb> options):base(options)
        {
                
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentaProductos { get; set; }

    }
}
