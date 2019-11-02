namespace Weather.Api.V1.Models
{
    using System;

    public class HistoryModel
    {
        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public int HighTemperature { get; set; }

        public int LowTemperature { get; set; }

        public int Wind { get; set; }

        public int Humidity { get; set; }
    }
}
