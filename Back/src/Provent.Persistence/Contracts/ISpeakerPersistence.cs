using System.Threading.Tasks;
using Provent.Domain;

namespace Provent.Persistence.Contracts
{
    public interface ISpeakerPersistence
    {
        //Speakers
        Task<Speaker[]> GetAllSpeakersByNameAsync(string nome, bool includeEvents = false);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false);
    }
}