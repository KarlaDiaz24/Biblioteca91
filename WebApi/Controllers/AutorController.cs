using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService) 
        {
          _autorService = autorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            var result = await _autorService.GetAutores();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerAutor(int id)
        {
            var result = await _autorService.ObtenerAutor(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] AutorDto request)
        {
            var result = await _autorService.CrearAutor(request);
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] AutorDto request, int id)
        {
            var result = await _autorService.ActualizarUsuario(request, id);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var result = await _autorService.EliminarUsuario(id);
            return Ok(result);
        }
    }
}
