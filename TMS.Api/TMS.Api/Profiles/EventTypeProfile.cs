using AutoMapper;
using TMS.Api.Models.Dto;
using TMS.Api.Models;

namespace TMS.Api.Profiles
{
    public class EventTypeProfile : Profile
    {
        public EventTypeProfile()
        {
            CreateMap<EventType, EventTypeDto>();
            CreateMap<Event, EventDto>().ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType)); 
        }
    }
}
