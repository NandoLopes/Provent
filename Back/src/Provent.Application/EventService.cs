using System;
using System.Threading.Tasks;
using AutoMapper;
using Provent.Application.Contract;
using Provent.Application.Dtos;
using Provent.Domain;
using Provent.Persistence.Contracts;

namespace Provent.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IEventPersistence _myEventPersistence;
        private readonly IMapper _mapper;

        public EventService(IGeneralPersistence generalPersistence, 
                            IEventPersistence myEventPersistence,
                            IMapper mapper)
        {
            _generalPersistence = generalPersistence;
            _myEventPersistence = myEventPersistence;
            _mapper = mapper;
        }
        public async Task<EventDto> AddEvents(EventDto model)
        {
            try
            {
                var myEvent = _mapper.Map<Event>(model);

                _generalPersistence.Add<Event>(myEvent);
                if(await _generalPersistence.SaveChangesAsync()){
                    var result = await _myEventPersistence.GetEventByIdAsync(myEvent.Id, false);
                    return _mapper.Map<EventDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> UpdateEvent(int myEventId, EventDto model)
        {
            try
            {
                var eventConfirm = await _myEventPersistence.GetEventByIdAsync(myEventId, false);
                if(eventConfirm == null) return null;

                model.Id = eventConfirm.Id;

                _mapper.Map(model, eventConfirm);

                _generalPersistence.Update<Event>(eventConfirm);
                if(await _generalPersistence.SaveChangesAsync()){
                    var result = await _myEventPersistence.GetEventByIdAsync(model.Id, false);
                    return _mapper.Map<EventDto>(result);
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
                 var myEvent = await _myEventPersistence.GetEventByIdAsync(myEventId, false) ?? throw new Exception("Event not found to delete.");

                _generalPersistence.Delete<Event>(myEvent);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                 var myEvents = await _myEventPersistence.GetAllEventsAsync(includeSpeakers);
                 if(myEvents == null) return null;

                 return _mapper.Map<EventDto[]>(myEvents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                 var myEvents = await _myEventPersistence.GetAllEventsByThemeAsync(theme, includeSpeakers);
                 if(myEvents == null) return null;

                 return _mapper.Map<EventDto[]>(myEvents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int myEventId, bool includeSpeakers = false)
        {
            try
            {
                 var myEvent = await _myEventPersistence.GetEventByIdAsync(myEventId, includeSpeakers);
                 if(myEvent == null) return null;

                 return _mapper.Map<EventDto>(myEvent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}