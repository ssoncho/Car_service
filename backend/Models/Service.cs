namespace CarServiceWebConsole.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<WorkerParticipation> WorkerParticipations { get; set; }
        public List<ServicePrice> ServicePrices { get; set; }
    }
}
