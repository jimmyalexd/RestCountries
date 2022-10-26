using Newtonsoft.Json;

namespace ProyectoApi.Models
{
    public class Name
    {
        [JsonProperty("common")]
        public string Common { get; set; }

        [JsonProperty("official")]
        public string Official { get; set; }
    }

    public class ApiRestCountryResponse
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("capital")]
        public List<string> Capital { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }
    }
}
