﻿namespace Weather.Api.V1.Models
{
    using Newtonsoft.Json;

    public class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }
}
