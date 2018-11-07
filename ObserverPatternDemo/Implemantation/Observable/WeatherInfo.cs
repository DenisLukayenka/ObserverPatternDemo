namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Pressure = pressure;
        }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Pressure { get; set; }
    }
}