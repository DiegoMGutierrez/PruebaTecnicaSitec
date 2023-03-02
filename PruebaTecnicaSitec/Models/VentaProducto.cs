using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSitec.Models
{
    public class VentaProducto
    {
        [Key]
        public int IdVentaProducto { get; set; }
        [ForeignKey("Venta")]
        public int IdVenta { get; set; }
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto? Producto { get; set; }
        [Required]
        public int CantidadProducto { get; set; }
        [Required]
        public decimal SubtotalProducto { get; set; }

    }
}
