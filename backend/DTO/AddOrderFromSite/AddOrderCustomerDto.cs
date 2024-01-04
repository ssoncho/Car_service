using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.AddOrderFromSite
{
    public class AddOrderCustomerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secondName")]
        public string? Patronymic { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("telegram")]
        public string TelegramAlias { get; set; }
    }
}
