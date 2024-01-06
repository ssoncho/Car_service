using CarServiceWebConsole.DTO.GetOrderById;
using CarServiceWebConsole.Mapper;
using CarServiceWebConsole.Services;
using CarServiceWebConsole.Services.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceWebConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public TelegramController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<int>>> GetOrdersByTgAlias([FromQuery] string tgAlias)
        {
            var ordersIds = await _orderService.GetOrdersIdsByTgAliasAsync($"{tgAlias}");
            var ordersIdsDto = ordersIds.ToDto();
            return Ok(ordersIdsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetOrderByIdResponseDto>> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                var orderDto = OrderTgMapper.ToDto(order);
                return Ok(orderDto);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
