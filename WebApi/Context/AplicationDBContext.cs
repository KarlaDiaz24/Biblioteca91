using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Contest
{
    public class AplicationDBContext:DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options) { }
        //Modelos
        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet <Rol> Roles { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PKUsuario = 1,
                    Nombre = "Karla",
                    User = "montsedays",
                    Password = "123",
                    FKRol = 1

                });
            //Insertar en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   PKRol = 1,
                   Nombre = "SuperAdmin"
               });
        }
        

    }
}
