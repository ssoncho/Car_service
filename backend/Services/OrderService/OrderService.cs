using CarServiceWebConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace CarServiceWebConsole.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            var existingCarOrDefault = await _context.Cars
                .FirstOrDefaultAsync(car =>
                car.Vin == order.Car.Vin
                || car.StateNumber == order.Car.StateNumber);
            var existingCustomerOrDefault = await _context.Customers
                .FirstOrDefaultAsync(customer => 
                customer.PhoneNumber == order.Car.Customer.PhoneNumber
                || customer.TelegramAlias == order.Car.Customer.TelegramAlias
                || customer.VkAlias == order.Car.Customer.VkAlias);
            
            if (existingCarOrDefault != null
                && !(existingCarOrDefault.ManufactureYear == order.Car.ManufactureYear
                    && existingCarOrDefault.Brand == order.Car.Brand
                    && existingCarOrDefault.Model == order.Car.Model
                    && existingCarOrDefault.Mileage == order.Car.Mileage
                    && existingCarOrDefault.Vin == order.Car.Vin
                    && existingCarOrDefault.StateNumber == order.Car.StateNumber))
            {
                throw new CarExistsException();
            }
            if (existingCustomerOrDefault != null
                && !(existingCustomerOrDefault.Name == order.Car.Customer.Name
                    && existingCustomerOrDefault.Patronymic == order.Car.Customer.Patronymic
                    && existingCustomerOrDefault.Surname == order.Car.Customer.Surname
                    && existingCustomerOrDefault.PhoneNumber == order.Car.Customer.PhoneNumber
                    && existingCustomerOrDefault.TelegramAlias == order.Car.Customer.TelegramAlias
                    && existingCustomerOrDefault.VkAlias == order.Car.Customer.VkAlias))
            {
                throw new CustomerExistsException();
            }

            if (existingCarOrDefault != null && existingCustomerOrDefault != null)
            {
                if (existingCarOrDefault.CustomerId != existingCustomerOrDefault.Id)
                    throw new CarAlreadyHasCustomerException();

                order.CarId = existingCarOrDefault.Id;
                order.Car = existingCarOrDefault;
            }
            else if (existingCarOrDefault == null && existingCustomerOrDefault != null)
            {
                order.Car.CustomerId = existingCustomerOrDefault.Id;
                order.Car.Customer = existingCustomerOrDefault;
            }
            else if (existingCarOrDefault != null && existingCustomerOrDefault == null)
            {
                throw new CarAlreadyHasCustomerException();
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(order => order.Car)
                    .ThenInclude(car => car.Customer)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.Worker)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.ServicePosition)
                .ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrdersByStatusAsync(Status status)
        {
            var orders = await _context.Orders
                .Include(order => order.Car)
                    .ThenInclude(car => car.Customer)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.Worker)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.ServicePosition)
                .Where(order => order.Status == status)
                .ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(order => order.Record)
                .Include(order => order.Car)
                    .ThenInclude(car => car.Customer)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.Worker)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.MaterialPositions)
                .Include(order => order.WorkerParticipations)
                        .ThenInclude(wp => wp.ServicePosition)
                .Include(order => order.ProductPositions)
                .FirstOrDefaultAsync(order => order.Id == id);

            if (order == null)
            {
                throw new NotFoundException("Order", id);
            }

            return order;
        }

        public async Task<List<int>> GetOrdersIdsByTgAliasAsync(string tgAlias)
        {
            var ordersIds = await _context.Orders
                .Where(o => o.Car.Customer.TelegramAlias == tgAlias)
                .Select(o => o.Id)
                .ToListAsync();
            if (ordersIds == null)
                return new List<int>();
            return ordersIds;
        }
    }
}
