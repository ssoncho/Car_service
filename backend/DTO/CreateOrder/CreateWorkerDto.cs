using Newtonsoft.Json;

namespace CarServiceWebConsole.DTO.CreateOrder
{
    public class CreateWorkerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patronymic")]
        public string? Patronymic { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}