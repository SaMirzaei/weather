namespace Weather.Api.V1.Models
{
    using Newtonsoft.Json;

    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
