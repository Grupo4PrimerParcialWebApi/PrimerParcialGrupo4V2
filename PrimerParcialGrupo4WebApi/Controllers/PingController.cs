using Microsoft.AspNetCore.Mvc;

namespace PrimerParcialGrupo4WebApi.Controllers
{
    [ApiController]
    [Route("ping")] // Ruta del endpoint
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("pong"); // Respuesta simple
        }
    }
}