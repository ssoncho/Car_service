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
    }
}
