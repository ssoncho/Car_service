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

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(order => order.Record)
                .Include(order => order.Car)
                    .ThenInclude(car => car.Customer)
                .Include(order => order.ProductPositions)
                .FirstOrDefaultAsync(order => order.Id == id);

            if (order == null)
            {
                throw new NotFoundException("Order", id);
            }

            if (order?.RecordId != null)
            {
                _context.Entry(order)
                    .Reference(order => order.Record)
                    .Query()
                    .Include(record => record.WorkerParticipations)
                        .ThenInclude(wp => wp.Worker)
                    .Include(record => record.WorkerParticipations)
                        .ThenInclude(wp => wp.MaterialPositions)
                    .Include(record => record.WorkerParticipations)
                        .ThenInclude(wp => wp.ServicePosition)
                    .Load();
            }

            return order;
        }
    }
}
