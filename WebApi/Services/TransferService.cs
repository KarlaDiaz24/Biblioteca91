using Dapper;
using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Contest;

namespace WebApi.Services
{
    public class TransferService : ITransferService
    {
        private readonly AplicationDBContext _context;
        public TransferService(AplicationDBContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Transfer>>> ObtenerUsuarios()
        {
            try
            {
                List<Transfer> response = new List<Transfer>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Transfer>("PATransfer", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Transfer>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Transfer>> ObtenerUsuario(int id)
        {
            try
            {
                Transfer response = await _context.Transfers.FirstOrDefaultAsync(x => x.Id == id);
                return new Response<Transfer>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Transfer>> CrearUsuario(TransferDto request)
        {
            try
            {
                Transfer transfer = new Transfer()
                {

                    Tipo = request.Tipo,
                    Descripcion = request.Descripcion,
                    Cantidad = request.Cantidad,
                    Fecha = request.Fecha,
                };
                _context.Transfers.Add(transfer);
                await _context.SaveChangesAsync();

                return new Response<Transfer>(transfer);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Transfer>> ActualizarUsuario(TransferDto request, int id)
        {
            try
            {
                Transfer transfer = await _context.Transfers.FirstOrDefaultAsync(x => x.Id == id);

                if (transfer == null)
                {
                    throw new Exception("No existe el usuario");
                }

                transfer.Tipo = request.Tipo;
                transfer.Descripcion = request.Descripcion;
                transfer.Cantidad = request.Cantidad;
                transfer.Fecha = request.Fecha;

                _context.Transfers.Update(transfer);
                await _context.SaveChangesAsync();
                return new Response<Transfer>(transfer);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Transfer>> EliminarUsuario(int id)
        {
            try
            {
                Transfer transfer = await _context.Transfers.FirstOrDefaultAsync(x => x.Id == id);

                if (transfer == null)
                {
                    throw new Exception("No existe el usuario");
                }

                _context.Transfers.Remove(transfer);
                await _context.SaveChangesAsync();
                return new Response<Transfer>(transfer);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}