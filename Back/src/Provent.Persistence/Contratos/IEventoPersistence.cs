using System.Threading.Tasks;
using Provent.Domain;

namespace Provent.Persistence.Contratos
{
    public interface IEventoPersistence
    {
        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}