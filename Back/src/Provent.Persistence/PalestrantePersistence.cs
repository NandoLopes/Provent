using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Provent.Domain;
using Provent.Persistence.Context;
using Provent.Persistence.Contratos;

namespace Provent.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProventContext _context;
        public PalestrantePersistence(ProventContext context)
        {
            _context = context;
        }

        //Palestrante
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(p => p.RedesSociais);

            if (includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
            query = query.OrderBy(p => p.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            
            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Id == palestranteId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}