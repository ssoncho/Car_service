namespace CarServiceWebConsole.DTO.GetOrderById
{
    public class WorkerParticipationDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public WorkerDto Worker { get; set; }
        public ServicePositionDto ServicePosition { get; set; }
        public List<MaterialPositionDto> MaterialPositions { get; set; }
    }

}
