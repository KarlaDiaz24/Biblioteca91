using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Contest;

namespace WebApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AplicationDBContext _context;
        public UsuarioService(AplicationDBContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x=>x.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x=>x.PKUsuario == id);
                return new Response<Usuario>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioDto request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {

                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FKRol = request.FkRol,
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> ActualizarUsuario(UsuarioDto request, int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PKUsuario == id);
                
                if(usuario == null)
                {
                    throw new Exception("No existe el usuario");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FKRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PKUsuario == id);

                if (usuario == null)
                {
                    throw new Exception("No existe el usuario");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
