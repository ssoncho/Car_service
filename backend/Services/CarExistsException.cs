namespace CarServiceWebConsole.Services
{
    public class CarExistsException : Exception
    {
        public CarExistsException()
            : base($"Car instance with these VIN/state number already exists.")
        {
        }
    }
}
