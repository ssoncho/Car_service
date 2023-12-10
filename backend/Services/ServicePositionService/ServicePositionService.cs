using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.ServicePositionService
{
    public class ServicePositionService : IServicePositionService
    {
        private readonly DataContext _context;

        public ServicePositionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServicePosition> CreateServicePositionAsync(ServicePosition servicePosition)
        {
            _context.ServicePositions.Add(servicePosition);
            await _context.SaveChangesAsync();
            return servicePosition;
        }
    }
}
