namespace CarServiceWebConsole.Services.CarService
{
    public interface ICarService
    {
        Task<Car> CreateCarAsync(Car car);
    }
}
