using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        public readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _transferService.ObtenerUsuarios();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _transferService.ObtenerUsuario(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] TransferDto request)
        {
            var result = await _transferService.CrearUsuario(request);
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] TransferDto request, int id)
        {
            var result = await _transferService.ActualizarUsuario(request, id);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var result = await _transferService.EliminarUsuario(id);
            return Ok(result);
        }
    }
}