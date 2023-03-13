using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Events.Models;
using Events.Services;
using Event.Services;

namespace Events.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventInfoRepository _eventInfoRepository;
        private readonly IMapper _mapper;
        IEnumerable<EventDto> events { get; set; } = null!;

        public EventsController(IEventInfoRepository eventInfoRepository,
            IMapper mapper)
        {
            _eventInfoRepository = eventInfoRepository ??
                throw new ArgumentNullException(nameof(eventInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public  ActionResult<IEnumerable<EventDto>> GetEvents()
        {
            var eventEntities = _eventInfoRepository.GetEventsAsync();
            return Ok(_mapper.Map<IEnumerable<EventDto>>(eventEntities));
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetEvent(int id)
        {
            // find event
            var eventToReturn = _eventInfoRepository.GetEventsAsync()
                                    .FirstOrDefault(c => c.Id == id);

            if (eventToReturn == null)
            {
                return NotFound();
            }

            eventToReturn.EventType = _eventInfoRepository.GetEventTypesForEventAsync(eventToReturn).FirstOrDefault(c => c.Id == id); ;


            return Ok(_mapper.Map<EventWithDetailsDto>(eventToReturn));

        }

    }
}