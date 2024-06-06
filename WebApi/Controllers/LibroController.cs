using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroservice;
        public LibroController(ILibroService libroservice)
        {
            _libroservice = libroservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetLibros()
        {
            var result = await _libroservice.GetLibros();
            return Ok(result);
        }
    }
}
