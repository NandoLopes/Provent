using System.Threading.Tasks;
using Provent.Persistence.Context;
using Provent.Persistence.Contracts;

namespace Provent.Persistence
{
    public class GeneralPersistence : IGeneralPersistence
    {
        private readonly ProventContext _context;
        public GeneralPersistence(ProventContext context)
        {
            _context = context;
        }

        //General
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}