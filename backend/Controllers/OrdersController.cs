﻿using AutoMapper;
using CarServiceWebConsole.DTO.AddOrderFromSite;
using CarServiceWebConsole.DTO.CreateOrder;
using CarServiceWebConsole.DTO.GetOrderById;
using CarServiceWebConsole.DTO.GetOrders;
using CarServiceWebConsole.Mapper;
using CarServiceWebConsole.Services;
using CarServiceWebConsole.Services.CarService;
using CarServiceWebConsole.Services.CustomerService;
using CarServiceWebConsole.Services.MaterialPositionService;
using CarServiceWebConsole.Services.OrderService;
using CarServiceWebConsole.Services.ProductPositionService;
using CarServiceWebConsole.Services.RecordService;
using CarServiceWebConsole.Services.ServicePositionService;
using CarServiceWebConsole.Services.ServiceService;
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
        private readonly IServiceService _serviceService;

        public OrdersController(IOrderService orderService, ICarService carService, ICustomerService customerService, IMaterialPositionService materialPositionService, IProductPositionService productPositionService, IRecordService recordService, IServicePositionService servicePositionService, IWorkerParticipationService workerParticipationService, IWorkerService workerService, IServiceService serviceService)
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
            _serviceService = serviceService;
        }

        [HttpPost("FromSite")]
        public async Task<IActionResult> AddOrderFromSiteAsync([FromBody] AddOrderFromSiteDto orderDto)
        {
            var order = orderDto.FromDto();
            var workerParticipation = order.WorkerParticipations.FirstOrDefault();
            if (workerParticipation != null)
            {
                var servicePrice = await _serviceService.GetServicePriceOrDefaultByName(workerParticipation.ServicePosition.Name);
                workerParticipation.ServicePosition.Price = servicePrice;
            }
            try
            {
                var result = await _orderService.CreateOrderAsync(order);
                return this.StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex) when (
                ex is CarAlreadyHasCustomerException
                || ex is CarExistsException
                || ex is CustomerExistsException
            )
            {
                return this.StatusCode(StatusCodes.Status409Conflict, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDTO orderDto)
        {
            var order = orderDto.FromDto();
            var workerParticipationsWithWorkers = order.WorkerParticipations
                .Where(wp => wp.Worker != null);
            try
            {
                foreach (var workerParticipation in workerParticipationsWithWorkers)
                {
                    var currentWorker = workerParticipation.Worker;
                    var existingWorker = await _workerService.GetWorkerByFullName(currentWorker.Name, currentWorker.Patronymic, currentWorker.Surname);
                    workerParticipation.WorkerId = existingWorker.MobileId;
                    workerParticipation.Worker = existingWorker;
                }
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

            try
            {
                var result = await _orderService.CreateOrderAsync(order);
                return CreatedAtAction("GetOrderById", new { id = result.Id }, new { OrderId = result.Id });
            }
            catch (Exception ex) when (
                ex is CarAlreadyHasCustomerException
                || ex is CarExistsException
                || ex is CustomerExistsException
            )
            {
                return Conflict(new {message = ex.Message});
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetOrderByIdResponseDto>> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                var orderDto = OrderMapper.ToDto(order);
                return Ok(orderDto);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GetOrdersResponseDto>>> GetOrders([FromQuery] string? status)
        {
            var statusMap = new Dictionary<string, Status>
            {
                { "not-viewed", Status.NotViewed },
                { "planned", Status.Planned },
                { "in-process", Status.InProcess },
                { "done", Status.Done }
            };

            List<Order> orders;
            if (status == null)
                orders = await _orderService.GetAllOrdersAsync();
            else
                orders = await _orderService.GetOrdersByStatusAsync(statusMap[status]);

            var ordersDto = orders.ToDto();
            return Ok(ordersDto);
        }
    }
}
