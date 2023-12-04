using System.ComponentModel.DataAnnotations;

namespace CarServiceWebConsole.Models
{
    public class Worker
    {
        [Key]
        public int MobileId { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }

        public List<WorkerParticipation> WorkerParticipations { get; set; }
    }
}
