using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.AddOrderFromSite
{
    public class AddOrderCustomerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patronymic")]
        public string? Patronymic { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("telegramAlias")]
        public string TelegramAlias { get; set; }
    }
}
