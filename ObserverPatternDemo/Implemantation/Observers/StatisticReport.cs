using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private IObservable<WeatherInfo> _observable;
        private int _averageTemperature;
        private int _averageHumidity;
        private int _averagePressure;
        private int _counter;

        public StatisticReport()
        {
        }

        public StatisticReport(IObservable<WeatherInfo> info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException(nameof(info) + " can't be null.");
            }

            _observable = info;
            _observable.Register(this);
        }

        public void Update(object sender, WeatherInfo info)
        {
            _counter++;
            _averageTemperature = (_averageTemperature + info.Temperature) / _counter;
            _averageHumidity = (_averageHumidity + info.Humidity) / _counter;
            _averagePressure = (_averagePressure + info.Pressure) / _counter;

            ReportInfo();
        }

        public void ReportInfo()
        {
            Console.WriteLine(
                $"Average statistic: temperature: {_averageTemperature}, humidity: {_averageHumidity}, pressure: {_averagePressure}.");
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