using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersistence
    {
        
        //Palestrantes

        
         Task<Palestrante[]> GetAllPalestratesByNomeAsync(string nome, bool includeEventos);

         Task<Palestrante[]> GetAllPalestratesAsync(bool includeEventos);

         Task<Palestrante> GetAllPalestratesByIdAsync(int palestrantesID, bool includeEventos);

    }
}