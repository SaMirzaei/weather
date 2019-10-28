namespace Weather.Api.V1.Models
{
    using Newtonsoft.Json;

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
