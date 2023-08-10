using AutoMapper;
using TMS.Api.Models.Dto;
using TMS.Api.Models;

namespace TMS.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.CustomerName)).ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Description));
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
       
    }
}
