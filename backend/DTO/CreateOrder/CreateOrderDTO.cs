using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.CreateOrder
{
    public class CreateOrderDTO
    {
        [JsonProperty("problemDescription")]
        public string ProblemDescription { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

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
