namespace Weather.Api.V1.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class OpenWeatherMap
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public int Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public List<Data> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
