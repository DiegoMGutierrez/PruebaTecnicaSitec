using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSitec.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public string DescripcionProducto { get; set; }
        [Required]
        public int StockProducto { get; set; }
        [Required]
        public decimal PrecioProducto { get; set; }
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
