using System.ComponentModel.DataAnnotations;
namespace PruebaTecnicaSitec.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        public string NombreCategoria { get; set; }
    }
}
