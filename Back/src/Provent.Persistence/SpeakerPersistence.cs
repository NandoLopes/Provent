using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Provent.Domain;
using Provent.Persistence.Context;
using Provent.Persistence.Contracts;

namespace Provent.Persistence
{
    public class SpeakerPersistence : ISpeakerPersistence
    {
        private readonly ProventContext _context;
        public SpeakerPersistence(ProventContext context)
        {
            _context = context;
        }

        //Speaker
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                    .Include(p => p.SocialNetworks);

            if (includeEvents){
                query = query
                    .Include(p => p.SpeakersEvents)
                    .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string nome, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(p => p.SocialNetworks);

            if (includeEvents){
                query = query
                    .Include(p => p.SpeakersEvents)
                    .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Name.ToLower().Contains(nome.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(p => p.SocialNetworks);

            if (includeEvents){
                query = query
                    .Include(p => p.SpeakersEvents)
                    .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Id == speakerId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}