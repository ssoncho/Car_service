namespace CarServiceWebConsole.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public string? Brand { get; set; }
        public string Vin { get; set; }
        public string StateNumber { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}
