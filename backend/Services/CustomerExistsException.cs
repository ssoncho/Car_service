namespace CarServiceWebConsole.Services
{
    public class CustomerExistsException : Exception
    {
        public CustomerExistsException()
            : base($"Customer instance with these tg/vk/phone number already exists.")
        {
        }
    }
}
