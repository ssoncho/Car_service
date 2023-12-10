using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO
{
    public class CreateCarDTO
    {

        [JsonProperty("mileage")]
        public int Mileage { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("stateNumber")]
        public string StateNumber { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("manufactureYear")]
        public int ManufactureYear { get; set; }

        [JsonProperty("customer")]
        public CreateCustomerDTO Customer { get; set; }
    }
}
