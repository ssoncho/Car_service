using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateOrderDTO
    {
        [JsonProperty("siteId")]
        public int? SiteId { get; set; }

        [JsonProperty("problemDescription")]
        public string ProblemDescription { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("creationDate")]
        public DateOnly CreationDate { get; set; }

        [JsonProperty("completionDate")]
        public DateOnly? CompletionDate { get; set; }

        [JsonProperty("car")]
        public CreateCarDTO Car { get; set; }

        [JsonProperty("customer")]
        public CreateCustomerDTO Customer { get; set; }

        [JsonProperty("record")]
        public CreateRecordDTO? Record { get; set; }

        [JsonProperty("workerParticipations")]
        public List<CreateWorkerParticipationNewOrderDTO> WorkerParticipations { get; set; }

        [JsonProperty("productPositions")]
        public List<CreateProductPositionNewOrderDTO> ProductPositions { get; set; }
    }
}
