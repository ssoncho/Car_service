using CarServiceWebConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace CarServiceWebConsole.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly DataContext _context;

        public ServiceService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> GetServicePriceOrDefaultByName(string name)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Name == name);
            if (service == null)
                return 0;
            return service.Price;
        }
    }
}
