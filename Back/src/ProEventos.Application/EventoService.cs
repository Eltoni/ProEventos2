using System.Threading.Tasks;
using proEventos.Domain;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence geralPersistence;
        private readonly IEventoPersistence eventoPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            this.eventoPersistence = eventoPersistence;
            this.geralPersistence = geralPersistence;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                geralPersistence.Add<Evento>(model);

                if(await geralPersistence.SaveChangesAsync()){

                    return await eventoPersistence.GetAllEventosByIdAsync(model.Id, false);

                }

                return null;
            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }


        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                
                var evento = await eventoPersistence.GetAllEventosByIdAsync(eventoId, false);

                if (evento == null) return null;

                model.Id = eventoId;

                geralPersistence.Update<Evento>(model);

                if(await geralPersistence.SaveChangesAsync()){

                 return await eventoPersistence.GetAllEventosByIdAsync(model.Id, false);

                }

                return null; 
            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }



        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                
                var evento = await eventoPersistence.GetAllEventosByIdAsync(eventoId, false);

                if (evento == null)  throw new System.Exception("Evento Para Deletar Não foi Encontrado");


                geralPersistence.Delete<Evento>(evento);

                return await geralPersistence.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosAsync(includePalestrante);

                if(eventos == null) return null;

                return eventos;

            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoID, bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosByIdAsync(EventoID,includePalestrante);

                if(eventos == null) return null;

                return eventos;

            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosByTemaAsync(tema,includePalestrante);

                if(eventos == null) return null;

                return eventos;

            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }
        }

       
    
}