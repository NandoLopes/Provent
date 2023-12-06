using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Provent.Domain;
using Provent.Persistence.Context;
using Provent.Persistence.Contracts;

namespace Provent.Persistence
{
    public class EventPersistence : IEventPersistence
    {
        private readonly ProventContext _context;
        public EventPersistence (ProventContext context)
        {
            _context = context;
        }

        //Events
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                    .Include(e => e.Batches)
                    .Include(e => e.SocialNetworks);

            if (includeSpeakers){
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(pe => pe.Speaker);
            }
            
            query = query.OrderBy(e => e.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers){
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(pe => pe.Speaker);
            }
            
            query = query.OrderBy(e => e.Id)
                    .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int myEventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers){
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(pe => pe.Speaker);
            }
            
            query = query.OrderBy(e => e.Id)
                    .Where(e => e.Id == myEventId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}