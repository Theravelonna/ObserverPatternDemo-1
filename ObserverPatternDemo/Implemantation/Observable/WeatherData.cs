using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class with weather data (observable).
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        private Random sensor;
        private WeatherInfo weatherInfo;
        private List<IObserver<WeatherInfo>> observers;

        /// <summary see cref="WeatherData">
        /// Constructor of class.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            weatherInfo = new WeatherInfo();
            sensor = new Random();
        }

        /// <summary>
        /// Method starts running of program.
        /// </summary>
        /// <param name="time">
        /// Runtime.
        /// </param>
        public void Start(int time)
        {
            Timer work = new Timer(Random, weatherInfo, 0, time);
        }

        /// <summary>
        /// Method unregisters new observers.
        /// </summary>
        /// <param name="observer">
        /// Observer for unregestration.
        /// </param>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Method registers new observers.
        /// </summary>
        /// <param name="observer">
        /// Observer for regestration.
        /// </param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        #region Private methods

        void IObservable<WeatherInfo>.Notify(WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(this, info);
            }
        }

        private void Random(object info)
        {
            WeatherInfo weatherInfo = (WeatherInfo)info;

            weatherInfo.Temperature = sensor.Next(-40, 40);
            weatherInfo.Humidity = sensor.Next(0, 100);
            weatherInfo.Pressure = sensor.Next(10, 40);

            (this as IObservable<WeatherInfo>).Notify(weatherInfo);
        }
        #endregion
    }
}