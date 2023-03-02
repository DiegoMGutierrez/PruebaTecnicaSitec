using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Services;

namespace PruebaTecnicaSitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(_service.GetClientes());
        }
    }
}
