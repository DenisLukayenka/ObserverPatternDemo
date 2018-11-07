using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> _listObservers;

        public WeatherData()
        {
            _listObservers = new List<IObserver<WeatherInfo>>();
        }

        void IObservable<WeatherInfo>.Notify(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException(nameof(info) + " can't be null.");
            }

            Notify(info);
        }

        public void SimulateNewWeatherData(int temperature, int humidity, int pressure)
        {
            Notify(new WeatherInfo(temperature, humidity, pressure));
        }

        public void SimulateNewWeatherData(WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info) + " reference to object can't be null.");
            }

            Notify(info);
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException(nameof(observer) + " can't be null.");
            }

            if (!_listObservers.Contains(observer))
            {
                _listObservers.Add(observer);
            }
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException(nameof(observer) + " can't be null.");
            }

            _listObservers.Remove(observer);
        }

        protected virtual void Notify(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException(nameof(info) + " can't be null.");
            }

            foreach (var observer in _listObservers)
            {
                observer.Update(this, info);
            }
        }
    }
}