using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class WorkerParticipation
    {
        [Key]
        public int ServicePositionId { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }
        public List<MaterialPosition> MaterialPositions { get; set; }
        public ServicePosition ServicePosition { get; set; }
    }
}
