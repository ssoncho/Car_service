using AutoMapper;
using CarServiceWebConsole.DTO;
using CarServiceWebConsole.Mapper;
using CarServiceWebConsole.Services.CarService;
using CarServiceWebConsole.Services.CustomerService;
using CarServiceWebConsole.Services.MaterialPositionService;
using CarServiceWebConsole.Services.OrderService;
using CarServiceWebConsole.Services.ProductPositionService;
using CarServiceWebConsole.Services.RecordService;
using CarServiceWebConsole.Services.ServicePositionService;
using CarServiceWebConsole.Services.WorkerParticipationService;
using CarServiceWebConsole.Services.WorkerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceWebConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        private readonly IMaterialPositionService _materialPositionService;
        private readonly IProductPositionService _productPositionService;
        private readonly IRecordService _recordService;
        private readonly IServicePositionService _servicePositionService;
        private readonly IWorkerParticipationService _workerParticipationService;
        private readonly IWorkerService _workerService;

        public OrdersController(IOrderService orderService, ICarService carService, ICustomerService customerService, IMaterialPositionService materialPositionService, IProductPositionService productPositionService, IRecordService recordService, IServicePositionService servicePositionService, IWorkerParticipationService workerParticipationService, IWorkerService workerService)
        {
            _orderService = orderService;
            _carService = carService;
            _customerService = customerService;
            _materialPositionService = materialPositionService;
            _productPositionService = productPositionService;
            _recordService = recordService;
            _servicePositionService = servicePositionService;
            _workerParticipationService = workerParticipationService;
            _workerService = workerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDTO orderDto)
        {
            var order = orderDto.FromDto();
            
            var result = await _orderService.CreateOrderAsync(order);
            return Created(new Uri($"{Request.Path}/{result.Id}", UriKind.Relative), new {OrderId = result.Id});
        }
    }
}
