using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class Record
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BoxId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<WorkerParticipation> WorkerParticipations { get; set; }
    }
}
