using System.Threading.Tasks;
using Provent.Domain;

namespace Provent.Persistence.Contracts
{
    public interface IEventPersistence
    {
        //Events
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int myEventId, bool includeSpeakers = false);
    }
}