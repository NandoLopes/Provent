using System;
using System.Threading.Tasks;
using Provent.Application.Contract;
using Provent.Domain;
using Provent.Persistence.Contracts;

namespace Provent.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IEventPersistence _myEventPersistence;

        public EventService(IGeneralPersistence generalPersistence, IEventPersistence myEventPersistence)
        {
            _generalPersistence = generalPersistence;
            _myEventPersistence = myEventPersistence;
        }
        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                _generalPersistence.Add<Event>(model);
                if(await _generalPersistence.SaveChangesAsync()){
                    return await _myEventPersistence.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int myEventId, Event model)
        {
            try
            {
                 var myEvent = await _myEventPersistence.GetEventByIdAsync(myEventId, false);
                 if(myEvent == null) return null;

                model.Id = myEvent.Id;

                _generalPersistence.Update(model);
                if(await _generalPersistence.SaveChangesAsync()){
                    return await _myEventPersistence.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int myEventId)
        {
            try
            {
                 var myEvent = await _myEventPersistence.GetEventByIdAsync(myEventId, false);
                 if(myEvent == null) throw new Exception("Event not found to delete.");

                _generalPersistence.Delete<Event>(myEvent);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                 var myEvents = await _myEventPersistence.GetAllEventsAsync(includeSpeakers);
                 if(myEvents == null) return null;

                 return myEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                 var myEvents = await _myEventPersistence.GetAllEventsByThemeAsync(theme, includeSpeakers);
                 if(myEvents == null) return null;

                 return myEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int myEventId, bool includeSpeakers = false)
        {
            try
            {
                 var myEvents = await _myEventPersistence.GetEventByIdAsync(myEventId, includeSpeakers);
                 if(myEvents == null) return null;

                 return myEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}