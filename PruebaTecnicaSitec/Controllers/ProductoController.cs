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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly ContextoDb _db;

        public ProductoController(IProductoService service, ContextoDb db)
        {
            _service = service;
            _db = db;
        }
        [HttpGet]
        public IActionResult GetProducto()
        {
            var result = _service.GetProductos();
            foreach (var obj in result)
            {
                var categoria = _db.Categorias.FirstOrDefault(x => x.IdCategoria == obj.IdCategoria);
                obj.Categoria = categoria;
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult PostProducto([FromBody] ProductoDTO body)
        {
            try
            {
                if (body.StockProducto < 0)
                {
                    return BadRequest("El stock no puede ser negativo");
                }
                if (body.PrecioProducto < 0)
                {
                    return BadRequest("El precio no puede ser negativo");
                }
                var categoria = _db.Categorias.FirstOrDefault(x => x.IdCategoria == body.IdCategoria);
                if (categoria != null)
                {
                    Producto producto = new Producto()
                    {
                        NombreProducto = body.NombreProducto,
                        DescripcionProducto = body.DescripcionProducto,
                        StockProducto = body.StockProducto,
                        PrecioProducto = body.PrecioProducto,
                        IdCategoria = body.IdCategoria
                    };
                    var result = _service.PostProducto(producto);
                    result.Categoria = categoria;
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Esta categoria no existe");
                }

            }
            catch
            {
                return BadRequest("Por favor ingrese datos validos");
            }
        }
        [HttpPut]
        public IActionResult PutProducto([FromHeader] int id, [FromBody] ProductoDTO body)
        {
            if (body.StockProducto < 0)
            {
                return BadRequest("El stock no puede ser negativo");
            }
            if (body.PrecioProducto < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }
            var categoria = _db.Categorias.FirstOrDefault(x => x.IdCategoria == body.IdCategoria);
            if (categoria == null)
            {
                return BadRequest("La categoria a asignar no existe");
            }
            Producto producto = new Producto()
            {
                NombreProducto = body.NombreProducto,
                DescripcionProducto = body.DescripcionProducto,
                StockProducto = body.StockProducto,
                PrecioProducto = body.PrecioProducto,
                IdCategoria = body.IdCategoria
            };
            var result = _service.PutProducto(id, producto);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("Este producto no existe");
        }
        [HttpDelete]
        public IActionResult DeleteProducto([FromHeader] int id)
        {
            var result = _service.DeleteProducto(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a eliminar no existe");
        }
        [HttpPatch("ModificarStock")]
        public IActionResult ModificarStock([FromHeader] int id, [FromHeader] int NuevoStock)
        {
            if (NuevoStock < 0)
            {
                return BadRequest("El stock no puede ser negativo");
            }
            var result = _service.PatchStock(id, NuevoStock);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a modificar no existe");
        }
        [HttpPatch("ModificarPrecio")]
        public IActionResult ModificarPrecio([FromHeader] int id, [FromHeader] decimal NuevoPrecio)
        {
            if (NuevoPrecio < 0)
            {
                return BadRequest("El precio no puede ser negativo");
            }
            var result = _service.PatchPrecio(id, NuevoPrecio);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest("El producto a modificar no existe");
        }
    } 
}

