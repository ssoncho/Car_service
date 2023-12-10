using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;

        public CarService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
