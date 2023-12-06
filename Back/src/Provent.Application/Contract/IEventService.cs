using Provent.Domain;
using System.Threading.Tasks;

namespace Provent.Application.Contract
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event model);
        Task<Event> UpdateEvent(int myEventId, Event model);
        Task<bool> DeleteEvent(int myEventId);

        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int myEventId, bool includeSpeakers = false);
    }
}