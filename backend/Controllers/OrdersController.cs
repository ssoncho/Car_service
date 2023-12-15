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
        public async Task<ActionResult<Order>> CreateOrderAsync([FromBody] CreateOrderDTO orderDto)
        {
            var order = orderDto.FromDto();
            var car = order.Car;
            var customer = car.Customer;
            await _customerService.CreateCustomerAsync(customer);
            await _carService.CreateCarAsync(car);
            var record = order.Record;
            if (record != null)
            {
                await _recordService.CreateRecordAsync(record);
                var workerParticipations = record.WorkerParticipations;
                var workers = workerParticipations.Select(wp => _workerService.GetWorkerById(wp.WorkerId));
                workerParticipations = workerParticipations
                    .Zip(workers, (wp, worker) => { wp.Worker = worker; return wp; })
                    .ToList();
                var materialPositionsPerWorkerParticipation = workerParticipations.Select(w => w.MaterialPositions);
                var servicePositionPerWorkerParticipation = workerParticipations.Select(w => w.ServicePosition);
                servicePositionPerWorkerParticipation.Select(async s => await _servicePositionService.CreateServicePositionAsync(s));
                materialPositionsPerWorkerParticipation.SelectMany(mPerw => mPerw)
                    .Select(async m => await _materialPositionService.CreateMaterialPositionAsync(m))
                    .ToList();
                workerParticipations
                    .Select(async w => await _workerParticipationService.CreateWorkerParticipationAsync(w))
                    .ToList();
            }
            
            var productPositions = order.ProductPositions;
            productPositions
                .Select(async p => await _productPositionService.CreateProductPositionAsync(p))
                .ToList();
            
            var result = await _orderService.CreateOrderAsync(order);
            return Ok(result);
        }
    }
}
