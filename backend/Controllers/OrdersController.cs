using AutoMapper;
using CarServiceWebConsole.DTO;
using CarServiceWebConsole.Services.CarService;
using CarServiceWebConsole.Services.CustomerService;
using CarServiceWebConsole.Services.MaterialPositionService;
using CarServiceWebConsole.Services.OrderService;
using CarServiceWebConsole.Services.ProductPositionService;
using CarServiceWebConsole.Services.RecordService;
using CarServiceWebConsole.Services.ServicePositionService;
using CarServiceWebConsole.Services.WorkerParticipationService;
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

        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrdersController(IOrderService orderService, ICarService carService, ICustomerService customerService, IMaterialPositionService materialPositionService, IProductPositionService productPositionService, IRecordService recordService, IServicePositionService servicePositionService, IWorkerParticipationService workerParticipationService)
        {
            _orderService = orderService;
            _carService = carService;
            _customerService = customerService;
            _materialPositionService = materialPositionService;
            _productPositionService = productPositionService;
            _recordService = recordService;
            _servicePositionService = servicePositionService;
            _workerParticipationService = workerParticipationService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(CreateOrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            var car = order.Car;
            var customer = car.Customer;
            var record = order.Record;
            var workerParticipations = record.WorkerParticipations;
            var materialPositionsPerWorkerParticipation = workerParticipations.Select(w => w.MaterialPositions);
            var servicePositionPerWorkerParticipation = workerParticipations.Select(w => w.ServicePosition);
            var productPositions = order.ProductPositions;

            await _customerService.CreateCustomerAsync(customer);
            await _carService.CreateCarAsync(car);
            servicePositionPerWorkerParticipation.Select(async s => await _servicePositionService.CreateServicePositionAsync(s));
            materialPositionsPerWorkerParticipation.SelectMany(mPerw => mPerw)
                .Select(async m => await _materialPositionService.CreateMaterialPositionAsync(m));
            workerParticipations.Select(async w => await _workerParticipationService.CreateWorkerParticipationAsync(w));
            await _recordService.CreateRecordAsync(record);
            productPositions.Select(async p => await _productPositionService.CreateProductPositionAsync(p));
            
            var result = await _orderService.CreateOrderAsync(order);
            return Ok(result);
        }
    }
}
