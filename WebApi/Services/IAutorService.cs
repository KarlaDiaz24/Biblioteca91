using Domain.Dto;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IAutorService
    {
        Task<Response<List<Autor>>> GetAutores();
        Task<Response<Autor>> ObtenerAutor(int id);
        Task<Response<Autor>> CrearAutor(AutorDto request);
        Task<Response<Autor>> ActualizarUsuario(AutorDto request, int id);
        Task<Response<Autor>> EliminarUsuario(int id);
    }
}
