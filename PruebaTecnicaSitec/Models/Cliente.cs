using System.ComponentModel.DataAnnotations;
namespace PruebaTecnicaSitec.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public string EmailCliente { get; set; }
        [Required]
        public string TelefonoCliente { get; set; }
        [Required]
        public string DNICliente { get; set; }
    }
}
