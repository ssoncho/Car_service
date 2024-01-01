namespace CarServiceWebConsole.Services
{
    public class CarAlreadyHasCustomerException : Exception
    {
        public CarAlreadyHasCustomerException()
            : base($"Car instance already has customer instance.")
        {
        }
    }
}
