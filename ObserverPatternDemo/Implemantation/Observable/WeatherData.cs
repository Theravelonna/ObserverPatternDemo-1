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
        private Random sensorTemperature;
        private Random sensorHumidity;
        private Random sensorPressure;
        private List<IObserver<WeatherInfo>> observers;

        /// <summary see cref="WeatherData">
        /// Constructor of class.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            sensorTemperature = new Random();
            sensorHumidity = new Random();
            sensorPressure = new Random();
        }

        /// <summary>
        /// Method starts running of program.
        /// </summary>
        /// <param name="time">
        /// Runtime.
        /// </param>
        public void ShowChanging(int time)
        {
            Timer work = new Timer(Random, null, 0, time);
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
            observers.Add(observer);
        }

        #region Private methods

        private void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(sender, info);
            }
        }

        void IObservable<WeatherInfo>.Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            Notify(this, info);
        }

        void IObservable<WeatherInfo>.Register(IObserver<WeatherInfo> observer)
        {
            Register(observer);
        }

        void IObservable<WeatherInfo>.Unregister(IObserver<WeatherInfo> observer)
        {
            Unregister(observer);
        }

        private void Random(object info)
        {
            WeatherInfo weatherInfo = (WeatherInfo)info;

            weatherInfo.Temperature = sensorTemperature.Next(-40, 40);
            weatherInfo.Humidity = sensorHumidity.Next(0, 100);
            weatherInfo.Pressure = sensorPressure.Next(10, 40);

            Notify(this, weatherInfo);
        }
        #endregion
    }
}