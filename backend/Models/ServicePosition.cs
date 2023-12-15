using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class ServicePosition
    {
        public int Id { get; set; }
        public WorkerParticipation WorkerParticipation { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
