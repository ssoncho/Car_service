using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class Record
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int BoxId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
