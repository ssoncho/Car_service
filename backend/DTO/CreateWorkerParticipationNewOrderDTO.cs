using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateWorkerParticipationNewOrderDTO
    {
        [JsonProperty("workerId")]
        public int WorkerId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("materials")]
        public List<CreateMaterialPositionNewOrderDTO> MaterialPositions { get; set; }

        [JsonProperty("service")]
        public CreateServicePositionNewOrderDTO ServicePosition { get; set; }
    }
}
