using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll().ToList();
         
            var ordersDTO = _mapper.Map<List<OrderDto>>(orders);
            return Ok(ordersDTO);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>>GetById(int id)
        {
            var @order = await _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var dtoOrder = _mapper.Map<OrderDto>(@order);
            return Ok(dtoOrder);

        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
          if(orderPatch.TotalPrice!=0)
            {
                orderEntity.TotalPrice =  orderPatch.TotalPrice;
            }
            if (orderPatch.NumberOfTickets != 0)
            {
                orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            }
            _orderRepository.Update(orderEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }

     /*   [HttpPost]
        public async Task<ActionResult> AddAsync(OrderAddDTO orderAddDTO)
        {
            Order orderSaved = await _orderService.SaveOrderAsync(orderAddDTO);
            return CreatedAtAction(nameof(GetById), new { id = orderSaved.OrderID }, orderSaved);

        }
*/
    }
}
