namespace CarServiceWebConsole.Models
{
    public class WorkerParticipation
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }

        public int RecordId { get; set; }
        public Record Record { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public List<MaterialPosition> MaterialPositions { get; set; }
        public ServicePosition ServicePosition { get; set; }
    }
}
