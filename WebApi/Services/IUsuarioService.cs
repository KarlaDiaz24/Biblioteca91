using Domain.Dto;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IUsuarioService
    {
        Task<Response<List<Usuario>>> ObtenerUsuarios();
        Task<Response<Usuario>> ObtenerUsuario(int id);
        Task<Response<Usuario>> CrearUsuario(UsuarioDto request);
        Task<Response<Usuario>> ActualizarUsuario(UsuarioDto request, int id);
        Task<Response<Usuario>> EliminarUsuario(int id);
    }
}
