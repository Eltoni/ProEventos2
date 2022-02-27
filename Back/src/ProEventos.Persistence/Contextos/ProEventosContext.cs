using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using proEventos.Domain;
using ProEventos.Domain;


namespace proEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public object Evento;

        public ProEventosContext(DbContextOptions<ProEventosContext> options ) : base(options){}
       
        
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<EventosPalestrantes> EventosPalestrantes { get; set; }
        public DbSet<RedeSocial> RedeSocias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
           modelBuilder.Entity<EventosPalestrantes>().HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            
           modelBuilder.Entity<Evento>()
           .HasMany(e => e.RedeSociais)
           .WithOne(rs => rs.Evento)
           .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Palestrante>()
           .HasMany(e => e.RedeSociais)
           .WithOne(rs => rs.Palestrante)
           .OnDelete(DeleteBehavior.Cascade);

           

        }
    }

}

