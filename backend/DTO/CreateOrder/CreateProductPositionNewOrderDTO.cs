using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.CreateOrder
{
    public class CreateProductPositionNewOrderDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
