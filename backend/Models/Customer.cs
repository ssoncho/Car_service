namespace CarServiceWebConsole.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramAlias { get; set; }
        public string? VkAlias { get; set; }
        public List<Car> Cars { get; set; }
    }
}