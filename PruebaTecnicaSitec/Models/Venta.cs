using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaSitec.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        [ForeignKey("Producto")]
        public decimal? TotalAntesDeImpuestos { get; set; }
        public decimal? TotalDespuesDeImpuestos { get; set; }
    }
}
