using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proEventos.Persistence;
using proEventos.Persistence.Contextos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext context;
        public PalestrantePersistence(ProEventosContext context)
        {
            this.context = context;

        }
        
         
        //Palestrante
        public async Task<Palestrante[]> GetAllPalestratesAsync(bool includeEventos  = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
            .Include(p => p.Nome)
            .Include(p => p.Telefone)
            .Include(p => p.MiniCurriculo);
            
            if(includeEventos){
                query = query.Include( p => p.EventosPalestrantes)
                        .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Id);

            

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestratesByIdAsync(int PalestrantesID, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
            .Include(p => p.Nome)
            .Include(p => p.Telefone)
            .Include(p => p.MiniCurriculo);
            
            if(includeEventos){
                query = query.Include( p => p.EventosPalestrantes)
                        .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == PalestrantesID);
            

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestratesByNomeAsync(string nome, bool includeEventos  = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
            .Include(p => p.Nome)
            .Include(p => p.Telefone)
            .Include(p => p.MiniCurriculo);
            
            if(includeEventos){
                query = query.Include( p => p.EventosPalestrantes)
                        .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


       
    }
}