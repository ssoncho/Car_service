namespace CarServiceWebConsole.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
