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
        public DateTime CreationDate { get; set; }

        [JsonProperty("completionDate")]
        public DateTime? CompletionDate { get; set; }

        [JsonProperty("car")]
        public CreateCarDTO Car { get; set; }

        [JsonProperty("record")]
        public CreateRecordDTO? Record { get; set; }

        [JsonProperty("products")]
        public List<CreateProductPositionNewOrderDTO>? ProductPositions { get; set; }
    }
}
