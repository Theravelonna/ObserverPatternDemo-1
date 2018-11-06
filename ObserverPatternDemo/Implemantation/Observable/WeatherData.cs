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
        private WeatherInfo weatherInfo;
        private List<IObserver<WeatherInfo>> observers;

        /// <summary see cref="WeatherData">
        /// Constructor of class.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
            weatherInfo = new WeatherInfo();
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
        public void Start(int countIteration)
        {
            int count = 0;
            while (count < countIteration)
            {
                Random();
                count++;
            }
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

        private void Random()
        {
            weatherInfo.Temperature = sensorTemperature.Next(-40, 40);
            weatherInfo.Humidity = sensorHumidity.Next(0, 100);
            weatherInfo.Pressure = sensorPressure.Next(10, 40);

            Notify(this, weatherInfo);
        }
        #endregion
    }
}