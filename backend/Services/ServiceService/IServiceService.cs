namespace CarServiceWebConsole.Services.ServiceService
{
    public interface IServiceService
    {
        Task<int> GetServicePriceOrDefaultByName(string name);
    }
}
