using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.AddOrderFromSite
{
    public class AddOrderCarDto
    {
        [JsonProperty("mileAge")]
        public int Mileage { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("stateNumber")]
        public string StateNumber { get; set; }
    }
}
