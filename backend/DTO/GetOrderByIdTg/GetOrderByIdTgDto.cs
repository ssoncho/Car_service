using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.GetOrderByIdTg
{
    public class GetOrderByIdTgDto
    {
        [JsonProperty("orderId")]
        public int Id { get; set; }
        [JsonProperty("problemDescription")]
        public string ProblemDescription { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("boxId")]
        public int? BoxId { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("services")]
        public List<ServiceTgDto> Services { get; set; }
    }
}
