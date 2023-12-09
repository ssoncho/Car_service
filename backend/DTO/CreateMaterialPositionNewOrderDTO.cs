using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateMaterialPositionNewOrderDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("clientHas")]
        public bool ClientHas { get; set; }
    }
}
