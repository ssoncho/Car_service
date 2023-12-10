namespace CarServiceWebConsole.Services.ServicePositionService
{
    public interface IServicePositionService
    {
        Task<ServicePosition> CreateServicePositionAsync(ServicePosition servicePosition);
    }
}
