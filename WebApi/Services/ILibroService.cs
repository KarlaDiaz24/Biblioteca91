using Domain.Dto;
using Domain.Entities;

namespace WebApi.Services
{
    public interface ILibroService
    {
        Task<Response<List<Libro>>> GetLibros();
        //Task<Response<Libro>> GetLibro(int id);
        //Task<Response<Libro>> PostLibro(Libro request);
        //Task<Response<Libro>> PutLibro(Libro request, int id);
        //Task<Response<Libro>> DeleteLibro(int id);
    }
}
