using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateServicePositionNewOrderDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
