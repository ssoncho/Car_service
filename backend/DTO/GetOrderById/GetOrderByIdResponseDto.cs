﻿namespace CarServiceWebConsole.DTO.GetOrderById
{
    public class GetOrderByIdResponseDto
{
    public int OrderId { get; set; }
    public string ProblemDescription { get; set; }
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public CarDto Car { get; set; }
    public CustomerDto Customer { get; set; }
    public RecordDto? Record { get; set; }
    public List<WorkerParticipationDto> WorkerParticipations { get; set; }
    public List<ProductPositionDto> ProductPositions { get; set; }
    public int TotalPrice { get; set; }
}

}
