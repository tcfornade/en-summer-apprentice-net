using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TMS.Api.Models;
using TMS.Api.Models.Dto;
using TMS.Api.Repository;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var dtoOrders = orders.Select(x => new OrderDto()
            {
                OrderId = x.OrderId,
                NumberOfTickets = x.NumberOfTickets,
                TotalPrice = x.TotalPrice,
                Customer = x.Customer?.CustomerName ?? string.Empty,
                TicketCategory = x.TicketCategory?.Description ?? string.Empty
            }); ;

            return Ok(dtoOrders);
        }

        [HttpGet]
        public ActionResult<OrderDto> GetById(int id)
        {
            var @order = _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var dtoOrder = new OrderDto()
            {
               OrderId =order.OrderId,
               NumberOfTickets = order.NumberOfTickets,
               TotalPrice = order.TotalPrice,
               Customer = order.Customer?.CustomerName ?? string.Empty,
               TicketCategory =order.TicketCategory?.Description ?? string.Empty
            };

            return Ok(dtoOrder);
        }
    }
}
