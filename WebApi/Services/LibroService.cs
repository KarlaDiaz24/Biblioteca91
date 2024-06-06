using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Contest;

namespace WebApi.Services
{
    public class LibroService : ILibroService
    {
        private readonly AplicationDBContext _context;
        public LibroService(AplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Libro>>> GetLibros()
        {
            try
            {
                List<Libro> response = new List<Libro>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Libro>("PALibro", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Libro>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
