namespace PruebaTecnicaSitec.DTO
{
    public class CarritoDeCompraDTO
    {
        public int IdCliente { get; set; }
        public List<ProductoVentaDTO> Productos { get; set; } = new List<ProductoVentaDTO>();
    }
}
