using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proEventos.Domain;
using proEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext context;
        public EventoPersistence(ProEventosContext context)
        {
            this.context = context;
           // this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
       
        public async Task<Evento> GetAllEventosByIdAsync(int EventoID, bool includePalestrante = false)
        {
             IQueryable<Evento> query = context.Eventos
            .Include( e => e.Lote)
            .Include(e => e.RedeSociais);
            
            if(includePalestrante){
                query = query.Include( e => e.EventosPalestrantes)
                        .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == EventoID);

            

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
            .Include( e => e.Lote)
            .Include(e => e.RedeSociais);
            
            if(includePalestrante){
                query = query.Include( e => e.EventosPalestrantes)
                        .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
            .Include( e => e.Lote)
            .Include(e => e.RedeSociais);
            
            if(includePalestrante){
                query = query.Include( e => e.EventosPalestrantes)
                        .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            

            return await query.ToArrayAsync();
        }
       
    }
}