namespace CarServiceWebConsole.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByStatusAsync(Status status);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
