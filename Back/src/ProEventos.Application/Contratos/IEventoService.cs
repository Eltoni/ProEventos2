using System.Threading.Tasks;

using proEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);

        Task<Evento> UpdateEventos(int eventoId, Evento model);

        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrante  = false);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);

        Task<Evento> GetAllEventosByIdAsync(int EventoID, bool includePalestrante  = false);
    }
}