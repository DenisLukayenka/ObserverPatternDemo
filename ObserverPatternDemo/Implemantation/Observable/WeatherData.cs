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

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException(nameof(sender) + " can't be null.");
            }

            if (ReferenceEquals(info, null))
            {
                throw new ArgumentNullException(nameof(info) + " can't be null.");
            }

            foreach (var observer in _listObservers)
            {
                observer.Update(sender, info);
            }
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
    }
}