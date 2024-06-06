using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista() 
        {
            var result = await _usuarioService.ObtenerUsuarios();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioService.ObtenerUsuario(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDto request)
        {
            var result = await _usuarioService.CrearUsuario(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] UsuarioDto request, int id)
        {
            var result = await _usuarioService.ActualizarUsuario(request, id);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarrUsuario(int id)
        {
            var result = await _usuarioService.EliminarUsuario(id);
            return Ok(result);
        }
    }
}
