using GestiondeEventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestiondeEventos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options ) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
