using Dapper;
using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Contest;

namespace WebApi.Services
{
    public class AutorService : IAutorService
    {
        private readonly AplicationDBContext _context;
        public AutorService(AplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("PAutor", new {}, commandType:CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Autor>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Autor>> ObtenerAutor(int id)
        {
            try
            {
                Autor response  = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpAutorId", new {ID = id }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Autor>> CrearAutor(AutorDto request)
        {
            try
            {
                Autor autor = new Autor();

                autor = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new { request.Nombre, request.Nacionalidad}, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                
                return new Response<Autor>(autor);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Autor>> ActualizarUsuario(AutorDto request, int id)
        {
            try
            {
                Autor autor = new Autor();

                autor = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpEditAutor",new { ID = id, request.Nombre, request.Nacionalidad },commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(autor);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
        public async Task<Response<Autor>> EliminarUsuario(int id)
        {
            try
            {
                Autor autor = new Autor();

                autor = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpEliminarAutor", new { ID = id }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                
                return new Response<Autor>(autor);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
