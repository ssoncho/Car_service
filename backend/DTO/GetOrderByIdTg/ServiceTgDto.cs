using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.GetOrderByIdTg
{
    public class ServiceTgDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}