using AutoMapper;
using Events.Models;

namespace Events.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, Models.EventDto>();
            CreateMap<Entities.Event, Models.EventWithDetailsDto>();
            CreateMap<Entities.EventType, Models.EventTypeDto>();
        }
    }
}
