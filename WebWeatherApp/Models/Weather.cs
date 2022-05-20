namespace WebWeatherApp.Models
{
    public class Weather
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public string CityName { get; set; }
        
    }
}
