using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Models.Dto;
using TMS.Api.Repository;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IMapper _mapper;

        public EventTypeController(IEventTypeRepository eventTypeRepository, IMapper mapper)
        {
            _eventTypeRepository = eventTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<EventTypeDto>> GetAll()
        {
            var eventType = _eventTypeRepository.GetAll();
            var dtoEventTypes = eventType.Select(e => _mapper.Map<EventTypeDto>(e));
            return Ok(dtoEventTypes);
        }

        [HttpGet]
        public async Task<ActionResult<EventTypeDto>> GetById(int id)
        {
            var @eventType = await _eventTypeRepository.GetById(id);
            var eventTypeDto = _mapper.Map<EventTypeDto>(@eventType);
            return Ok(eventTypeDto);
        }
    }
}
