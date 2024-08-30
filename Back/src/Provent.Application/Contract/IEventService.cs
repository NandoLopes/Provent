using Provent.Application.Dtos;
using System.Threading.Tasks;

namespace Provent.Application.Contract
{
    public interface IEventService
    {
        Task<EventDto> AddEvents(EventDto model);
        Task<EventDto> UpdateEvent(int myEventId, EventDto model);
        Task<bool> DeleteEvent(int myEventId);

        Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<EventDto> GetEventByIdAsync(int myEventId, bool includeSpeakers = false);
    }
}