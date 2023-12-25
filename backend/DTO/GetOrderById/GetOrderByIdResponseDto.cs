namespace CarServiceWebConsole.DTO.GetOrderById
{
    public class GetOrderByIdResponseDto
{
    public int OrderId { get; set; }
    public int? SiteId { get; set; }
    public string ProblemDescription { get; set; }
    public string Status { get; set; }
    public DateOnly CreationDate { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public CarDto Car { get; set; }
    public CustomerDto Customer { get; set; }
    public RecordDto? Record { get; set; }
    public List<ProductPositionDto> ProductPositions { get; set; }
}

}
