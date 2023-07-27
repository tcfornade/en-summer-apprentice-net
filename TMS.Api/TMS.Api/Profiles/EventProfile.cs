using AutoMapper;
using TMS.Api.Models.Dto;
using TMS.Api.Models;

namespace TMS.Api.Profiles

{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }       
    }
}
