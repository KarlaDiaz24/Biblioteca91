using Domain.Dto;
using Domain.Entities;

namespace WebApi.Services
{
    public interface ITransferService
    {
        Task<Response<List<Transfer>>> ObtenerUsuarios();
        Task<Response<Transfer>> ObtenerUsuario(int id);
        Task<Response<Transfer>> CrearUsuario(TransferDto request);
        Task<Response<Transfer>> ActualizarUsuario(TransferDto request, int id);
        Task<Response<Transfer>> EliminarUsuario(int id);
    }
}
