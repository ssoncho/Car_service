using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateRecordDTO
    {
        [JsonProperty("boxId")]
        public int BoxId { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("workerParticipations")]
        public List<CreateWorkerParticipationNewOrderDTO> WorkerParticipations { get; set; }
    }
}
