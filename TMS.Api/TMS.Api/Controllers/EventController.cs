using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TMS.Api.Exceptions;
using TMS.Api.Models;
using TMS.Api.Models.Dto;
using TMS.Api.Repository;


namespace TMS.Api.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            /*var events = _eventRepository.GetAll();
            var dtoEvents = events.Select(e =>
            {
                var dto = _mapper.Map<EventDto>(e);
                dto.EventTypeName = e.EventType?.EventTypeName ?? string.Empty;
                return dto;
             });
            return Ok(dtoEvents);*/

            var events = _eventRepository.GetAll();
            //var eventsDto = events.Select(e => _mapper.Map<EventDto>(e));
            var eventsDTO = _mapper.Map<List<EventDto>>(events);
            return Ok(eventsDTO);
        }


        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);
            
            var eventDto = _mapper.Map<EventDto>(@event);

            return Ok(eventDto);
        }

        [HttpGet]
        public ActionResult<EventDto> GetByName(string nameEvent)
        {
            var @event = _eventRepository.GetByName(nameEvent);

            if (@event == null)
            {
                return NotFound();
            }

            
            return Ok(@event);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            if (eventPatch == null) 
                throw new ArgumentNullException(nameof(eventPatch));
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if (eventEntity == null)
            {
                return NotFound();
            }
            if (!eventPatch.EventName.IsNullOrEmpty()) eventEntity.EventName = eventPatch.EventName;
            if (!eventPatch.EventDescription.IsNullOrEmpty()) eventEntity.EventDescription = eventPatch.EventDescription;
            _eventRepository.Update(eventEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}

