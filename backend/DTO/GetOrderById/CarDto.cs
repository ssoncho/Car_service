namespace CarServiceWebConsole.DTO.GetOrderById
{
    public class CarDto
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public string? Brand { get; set; }
        public string Vin { get; set; }
        public string StateNumber { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
    }

}
