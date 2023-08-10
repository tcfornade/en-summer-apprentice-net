using AutoMapper;
using TMS.Api.Models;
using TMS.Api.Models.Dto;

namespace TMS.Api.Profiles
{
    public class TicketCategoryProfile : Profile
    {
        public TicketCategoryProfile() {
            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();
        }
       
    }
}
