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

        public CurrentConditionsReport()
        {
        }

        public CurrentConditionsReport(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentNullException(nameof(observable) + " can't be null.");
            }

            _observable = observable;
            _observable.Register(this);
        }

        public void Update(object sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException(nameof(info) + " reference can't be null.");
            }

            _currentTemperature = info.Temperature;
            _currentHumidity = info.Humidity;
            _currentPressure = info.Pressure;

            ReportInfo();
        }

        public void ReportInfo()
        {
            Console.WriteLine(
                $"Weather info: pressure: {_currentPressure}, humidity: {_currentHumidity}, temperature: {_currentTemperature}.");
        }

        public void Register(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentNullException(nameof(observable) + " reference to object is null.");
            }

            observable.Register(this);
        }

        public void Unregister(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentNullException(nameof(observable) + " reference to object is null.");
            }

            observable.Unregister(this);
        }
    }
}