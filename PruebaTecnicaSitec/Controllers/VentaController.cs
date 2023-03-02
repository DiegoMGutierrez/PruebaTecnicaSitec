using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.DTO;
using PruebaTecnicaSitec.Models;
using PruebaTecnicaSitec.Services;

namespace PruebaTecnicaSitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaservice;
        private readonly IProductoService _productoservice;
        private readonly IVentaProductoService _ventaProductoService;

        private readonly ContextoDb _db;
        public VentaController(IVentaService ventaservice, IProductoService productoService,ContextoDb db, IVentaProductoService ventaProductoService)
        {
            _ventaservice = ventaservice;
            _db = db;
            _productoservice = productoService;
            _ventaProductoService = ventaProductoService;
        }
        [HttpGet("ListarVentas")]
        public IActionResult GetVentas()
        {
            List<DetalleDTO> detalles= new List<DetalleDTO>();
            var result = _ventaservice.GetVentas();
            foreach(var objVenta in result)
            {
                var detalleProductos = _ventaProductoService.GetPorIdVenta(objVenta.IdVenta);
                var cliente = _db.Clientes.Find(objVenta.IdCliente);
                objVenta.Cliente = cliente;

                DetalleDTO detalle = new DetalleDTO()
                {
                    Venta = objVenta
                };
                foreach(var objProductos in detalleProductos)
                {
                    var producto = _db.Productos.Find(objProductos.IdProducto);
                    var categoria = _db.Categorias.Find(producto.IdCategoria);
                    producto.Categoria = categoria;
                    objProductos.Producto = producto;
                    detalle.Productos.Add(objProductos);
                }

                detalles.Add(detalle);
            }
            return Ok(detalles);
        }

        [HttpGet("ListarVentasPorCliente")]
        public IActionResult GetVentasPorCliente([FromHeader]int id)
        {
            var clienteverif = _db.Clientes.Find(id);
            if (clienteverif == null)
            {
                return BadRequest("Este cliente no existe");
            }
            List<DetalleDTO> detalles = new List<DetalleDTO>();

            var result = _ventaservice.GetVentasPorCliente(id);
            foreach (var objVenta in result)
            {
                var detalleProductos = _ventaProductoService.GetPorIdVenta(objVenta.IdVenta);
                var cliente = _db.Clientes.Find(objVenta.IdCliente);
                objVenta.Cliente = cliente;

                DetalleDTO detalle = new DetalleDTO()
                {
                    Venta = objVenta
                };
                foreach (var objProductos in detalleProductos)
                {
                    var producto = _db.Productos.Find(objProductos.IdProducto);
                    var categoria = _db.Categorias.Find(producto.IdCategoria);
                    producto.Categoria = categoria;
                    objProductos.Producto = producto;
                    detalle.Productos.Add(objProductos);
                }

                detalles.Add(detalle);
            }
            return Ok(detalles);
        }
        [HttpGet("ListarVentasPorProducto")]
        public IActionResult GetVentasPorProducto([FromHeader] int id)
        {
            var productoverif = _db.Productos.Find(id);
            if (productoverif == null) { 
                return BadRequest("Este producto no existe");
            }
            List<DetalleDTO> detalles = new List<DetalleDTO>();

            var result = _ventaservice.GetVentasPorProducto(id);
            foreach (var objVenta in result)
            {
                var detalleProductos = _ventaProductoService.GetPorIdVenta(objVenta.IdVenta);
                var cliente = _db.Clientes.Find(objVenta.IdCliente);
                objVenta.Cliente = cliente;

                DetalleDTO detalle = new DetalleDTO()
                {
                    Venta = objVenta
                };
                foreach (var objProductos in detalleProductos)
                {
                    var producto = _db.Productos.Find(objProductos.IdProducto);
                    var categoria = _db.Categorias.Find(producto.IdCategoria);
                    producto.Categoria = categoria;
                    objProductos.Producto = producto;
                    detalle.Productos.Add(objProductos);
                }

                detalles.Add(detalle);
            }
            return Ok(detalles);
        }

        [HttpPost("ProcesarVenta")]
        public IActionResult ProcesarVenta([FromBody] CarritoDeCompraDTO body)
        {
            decimal sumatoriaPrecio = 0;
            var cliente = _db.Clientes.Find(body.IdCliente);
            if (cliente == null)
            {
                return BadRequest("Este cliente no existe");
            }
            foreach (var obj in body.Productos)
            {
                var producto = _db.Productos.Find(obj.IdProducto);
                if (producto == null)
                {
                    return BadRequest("El producto "+obj.IdProducto.ToString()+" no existe");
                }
                if (producto.StockProducto < obj.Cantidad)
                {
                    return BadRequest("No hay suficiente stock del producto "+obj.Cantidad.ToString());
                }
                sumatoriaPrecio += producto.PrecioProducto *obj.Cantidad;
            }
            Venta venta = new Venta()
            {
                IdCliente = body.IdCliente,
                TotalAntesDeImpuestos = sumatoriaPrecio,
                TotalDespuesDeImpuestos = sumatoriaPrecio * Convert.ToDecimal(1.13)
            };
            var result = _ventaservice.PostVenta(venta);
            result.Cliente = cliente;
            DetalleDTO detalle = new DetalleDTO()
            {
                Venta = result,
            };
            foreach (var obj in body.Productos)
            {
                var producto = _db.Productos.Find(obj.IdProducto);

                VentaProducto ventaProducto = new VentaProducto() 
                { 
                    IdProducto = producto.IdProducto,
                    IdVenta = result.IdVenta,
                    CantidadProducto = obj.Cantidad,
                    SubtotalProducto = producto.PrecioProducto * obj.Cantidad
                };
                _ventaProductoService.PostVentaProducto(ventaProducto);
                _productoservice.PatchStock(producto.IdProducto, producto.StockProducto - obj.Cantidad);
                detalle.Productos.Add(ventaProducto);
            }
            
            return Ok(detalle);

        }
    }
}
