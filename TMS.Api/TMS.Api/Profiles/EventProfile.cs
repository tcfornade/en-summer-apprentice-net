using AutoMapper;
using TMS.Api.Models.Dto;
using TMS.Api.Models;

namespace TMS.Api.Profiles

{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            // CreateMap<Event, EventDto>().ReverseMap();

            CreateMap<Event, EventDto>().ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.EventTypeName))
                .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue.Location)).ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategories.Where(tc => tc.EventId == src.EventId).Select(tc => new TicketCategoryDto
                {
                    TicketCategoryId = tc.TicketCategoryId,
                    EventId = tc.EventId,
                    Description = tc.Description,
                    Price = tc.Price

                }).ToList()));


            CreateMap<Event, EventPatchDto>().ReverseMap();
        }       
    }
}
