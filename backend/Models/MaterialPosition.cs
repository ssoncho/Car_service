namespace CarServiceWebConsole.Models
{
    public class MaterialPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool ClientHas { get; set; }

        public int WorkerParticipationId { get; set; }
        public WorkerParticipation WorkerParticipation { get; set; }
    }
}
