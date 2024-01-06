using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.CreateOrder
{
    public class CreateWorkerParticipationNewOrderDTO
    {
        [JsonProperty("worker")]
        public CreateWorkerDto? Worker { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("materialPositions")]
        public List<CreateMaterialPositionNewOrderDTO> MaterialPositions { get; set; }

        [JsonProperty("servicePosition")]
        public CreateServicePositionNewOrderDTO ServicePosition { get; set; }
    }
}
