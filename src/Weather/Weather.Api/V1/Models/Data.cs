namespace Weather.Api.V1.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Data
    {
        [JsonProperty("dt")]
        public int DT { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string DT_txt { get; set; }
    }
}
