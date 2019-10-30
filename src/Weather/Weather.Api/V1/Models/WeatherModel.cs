namespace Weather.Api.V1.Models
{
    public class WeatherModel
    {
        public string Coutnry { get; set; }

        public string City { get; set; }

        public double MinTemperature { get; set; }

        public double MaxTemperature { get; set; }

        public int Humidity { get; set; }

        public int Wind { get; set; }
    }
}
