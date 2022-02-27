using System.Threading.Tasks;
using proEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersistence
    {
        

         //Eventos

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);

         Task<Evento[]> GetAllEventosAsync(bool includePalestrante);

         Task<Evento> GetAllEventosByIdAsync(int eventoID, bool includePalestrante);

        
       
    }
}