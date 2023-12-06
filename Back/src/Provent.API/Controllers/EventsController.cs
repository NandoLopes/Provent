using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Provent.Application.Contract;
using Provent.Domain;
using System;
using System.Threading.Tasks;

namespace Provent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _myEventService;
        public EventsController(IEventService myEventService)
        {
            _myEventService = myEventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myEvents = await _myEventService.GetAllEventsAsync(true);
                return myEvents != null ? Ok(myEvents) : NotFound("No event found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error when trying to retrieve events. Error: {ex.Message}");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var myEvent = await _myEventService.GetEventByIdAsync(id, true);
                return myEvent != null ? Ok(myEvent) : NotFound("No event found with this id.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error when trying to retrieve event by id. Error: {ex.Message}");
                throw;
            }
        }

        [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var myEvents = await _myEventService.GetAllEventsByThemeAsync(theme, true);
                return myEvents != null ? Ok(myEvents) : NotFound("No event found with this theme.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to retrieve event by theme. Error: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var myEvents = await _myEventService.AddEvents(model);
                return myEvents != null ? Ok(myEvents) : BadRequest("Error when trying to add event.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error when trying to insert event. Error: {ex.Message}");
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var myEvents = await _myEventService.UpdateEvent(id, model);
                return myEvents != null ? Ok(myEvents) : BadRequest("Error when trying to update event.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error when trying to update event. Error: {ex.Message}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _myEventService.DeleteEvent(id) ?
                            Ok("Deleted") :
                            BadRequest("Error on delete");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error when trying to delete event. Error: {ex.Message}");
                throw;
            }
        }
    }
}
