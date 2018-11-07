using System;
using System.Threading;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    public class Station
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            WeatherData observable = new WeatherData();

            StatisticReport reporter = new StatisticReport();
            CurrentConditionsReport condition = new CurrentConditionsReport(observable);
            reporter.Register(observable);

            TimerCallback callback = GenerateInfo;
            Timer timer = new Timer(callback, observable, 0, 2000);

            if (Console.ReadKey() != null)
            {
                timer.Dispose();
            }

            Console.ReadKey();
        }

        private static void GenerateInfo(object obj)
        {
            WeatherInfo info = GenerateWeatherInfo();
            WeatherData data = obj as WeatherData;

            ViewWeatherInfo(info);

            data?.SimulateNewWeatherData(info);

            Console.WriteLine("---------------------------------------");
        }

        private static WeatherInfo GenerateWeatherInfo()
        {
            int temperature = random.Next(-80, 60);
            int humidity = random.Next(100);
            int pressure = random.Next(600, 800);

            return new WeatherInfo(temperature, humidity, pressure);
        }

        private static void ViewWeatherInfo(WeatherInfo info)
        {
            Console.WriteLine($"Weather: temperature: {info.Temperature}, humidity: {info.Humidity}, pressure: {info.Pressure}.");
        }
    }
}
