using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.AddOrderFromSite
{
    public class AddOrderFromSiteDto
    {
        [JsonProperty("siteId")]
        public int SiteId { get; set; }

        [JsonProperty("description")]
        public string ProblemDescription { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("completedAt")]
        public DateTime? CompletionDate { get; set; }

        [JsonProperty("car")]
        public AddOrderCarDto Car { get; set; }

        [JsonProperty("customer")]
        public AddOrderCustomerDto Customer { get; set; }
    }
}
