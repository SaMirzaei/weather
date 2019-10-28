﻿namespace Weather.Api.V1.Models
{
    using Newtonsoft.Json;

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
}
