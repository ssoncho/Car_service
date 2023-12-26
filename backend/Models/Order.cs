using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? SiteId { get; set; }
        public string ProblemDescription { get; set; }
        public Status Status { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? CompletionDate { get; set; }

        public int? RecordId { get; set; }
        public Record? Record { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public List<ProductPosition> ProductPositions { get; set; }
        public List<WorkerParticipation> WorkerParticipations { get; set; }
    }
}
