using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherInfo info = new WeatherInfo()
            {
                Humidity = 80,
                Pressure = 800,
                Temperature = 26
            };

            WeatherData observable = new WeatherData();

            StatisticReport reporter = new StatisticReport(observable);
            CurrentConditionsReport condition = new CurrentConditionsReport(observable);

            observable.Notify(observable, info);

            reporter.Report();
            condition.Report();

            info.Pressure = 1200;
            info.Humidity = 12;
            info.Temperature = 40;

            observable.Notify(observable, info);
            reporter.Report();
            condition.Report();
            Console.ReadKey();
        }
    }
}
