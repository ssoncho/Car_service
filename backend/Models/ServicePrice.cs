namespace CarServiceWebConsole.Models
{
    public class ServicePrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
