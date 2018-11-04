using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private IObservable<WeatherInfo> _observable;
        private int _currentTemperature;
        private int _currentHumidity;
        private int _currentPressure;

        public CurrentConditionsReport(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentNullException(nameof(observable) + " can't be null.");
            }

            _observable = observable;
            _observable.Register(this);
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            _currentTemperature = info.Temperature;
            _currentHumidity = info.Humidity;
            _currentPressure = info.Pressure;
        }

        public void Report()
        {
            Console.WriteLine($"Weather info: pressure: {_currentPressure}, humidity: {_currentHumidity}, temperature: {_currentTemperature}.");
        }
    }
}