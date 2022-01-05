using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using proEventos.API.Models;
namespace proEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options){}
        public DbSet<Evento> Eventos { get; set; }
    }
}